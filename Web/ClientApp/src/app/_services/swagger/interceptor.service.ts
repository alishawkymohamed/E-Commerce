import { Injectable, Renderer2, RendererFactory2 } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs/index';
import {
  catchError,
  delay,
  finalize,
  map,
  mergeMap,
  retryWhen,
  take
} from 'rxjs/internal/operators';
import { Router } from '@angular/router';
import { TokenStoreService } from '../token-store.service';
import { AuthTokenType } from 'src/app/_models/auth-token-type';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {
  private renderer: Renderer2;
  private delayBetweenRetriesMs = 1000;
  private numberOfRetries = 3;
  private authorizationHeader = 'Authorization';

  constructor(
    private rendererFactory: RendererFactory2,
    private tokenStoreService: TokenStoreService,
    private router: Router
  ) {
    this.renderer = rendererFactory.createRenderer(null, null);
  }

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const accessToken = this.tokenStoreService.getRawAuthToken(
      AuthTokenType.AccessToken
    );
    this.renderer.addClass(document.body, 'isLoading');
    request = request.clone({ withCredentials: true });
    if (accessToken && !request.url.toUpperCase().endsWith('login'.toUpperCase())) {
      request = request.clone({
        headers: request.headers.set(
          this.authorizationHeader,
          `Bearer ${accessToken}`
        )
      });

      return next.handle(request).pipe(
        retryWhen(errors =>
          errors.pipe(
            mergeMap((error: HttpErrorResponse, retryAttempt: number) => {
              if (retryAttempt === this.numberOfRetries - 1) {
                console.log(
                  `HTTP call '${request.method} ${request.url}' failed after ${
                  this.numberOfRetries
                  } retries.`
                );
                return throwError(error); // no retry
              }

              switch (error.status) {
                case 400:
                case 404:
                case 500:
                  return throwError(error); // no retry
              }

              return of(error); // retry
            }),
            delay(this.delayBetweenRetriesMs),
            take(this.numberOfRetries)
          )
        ),
        catchError((error: any, caught: Observable<HttpEvent<any>>) => {
          console.error({ error, caught });
          if (error.status === 401 || error.status === 403) {
            const newRequest = this.getNewAuthRequest(request);
            if (newRequest) {
              console.log('Try new AuthRequest ...');
              return next.handle(newRequest);
            }
            this.router.navigate(['/login']);
          }
          return throwError(error);
        }),
        finalize(() => {
          this.renderer.removeClass(document.body, 'isLoading');
        })
      );
    } else {
      // login page
      return next.handle(request).pipe(
        finalize(() => {
          this.renderer.removeClass(document.body, 'isLoading');
        })
      );
    }
  }

  getNewAuthRequest(request: HttpRequest<any>): HttpRequest<any> | null {
    const newStoredToken = this.tokenStoreService.getRawAuthToken(
      AuthTokenType.AccessToken
    );
    const requestAccessTokenHeader = request.headers.get(
      this.authorizationHeader
    );
    if (!newStoredToken || !requestAccessTokenHeader) {
      console.log('There is no new AccessToken.', {
        requestAccessTokenHeader: requestAccessTokenHeader,
        newStoredToken: newStoredToken
      });
      return null;
    }
    const newAccessTokenHeader = `Bearer ${newStoredToken}`;
    if (requestAccessTokenHeader === newAccessTokenHeader) {
      console.log('There is no new AccessToken.', {
        requestAccessTokenHeader: requestAccessTokenHeader,
        newAccessTokenHeader: newAccessTokenHeader
      });
      return null;
    }
    return request.clone({
      headers: request.headers.set(
        this.authorizationHeader,
        newAccessTokenHeader
      ),
      withCredentials: true
    });
  }
}
