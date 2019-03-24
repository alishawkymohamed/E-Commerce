import { Injectable } from '@angular/core';
import {
  AccessToken,
  AuthTicketDTO,
  SwaggerClient,
  UserLoginDTO
} from './swagger/SwaggerClient.service';
import { BehaviorSubject, Observable, throwError } from 'rxjs/index';
import { Router } from '@angular/router';
import { TokenStoreService } from './token-store.service';
import { RefreshTokenService } from './refresh-token.service';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AuthTokenType } from '../_models/auth-token-type';
import { catchError, finalize, map } from 'rxjs/internal/operators';
import { BrowserStorageService } from './browser-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private user = new BehaviorSubject<AuthTicketDTO>(null);
  currentUser = this.user.asObservable();

  private authStatusSource = new BehaviorSubject<boolean>(false);
  authStatus$ = this.authStatusSource.asObservable();

  constructor(
    private swagger: SwaggerClient,
    private router: Router,
    private browserStorageService: BrowserStorageService,
    private tokenStoreService: TokenStoreService,
    private refreshTokenService: RefreshTokenService
  ) {
    this.updateStatusOnPageRefresh();
    this.refreshTokenService.scheduleRefreshToken(this.isAuthUserLoggedIn());

    const user = localStorage.getItem('user');
    if (user) {
      this.user.next(JSON.parse(user));
    }
  }

  setUser(user) {
    this.user.next(user);
    this.browserStorageService.setLocal('User', JSON.stringify(user));
  }

  login(credentials: UserLoginDTO): Observable<boolean> {
    return this.swagger.api_Account_Login(credentials).pipe(
      map((response: AccessToken) => {
        if (!response) {
          console.error(
            'There is no "access-token", "refresh-token" response after login.'
          );
          this.authStatusSource.next(false);
          return false;
        }
        this.tokenStoreService.storeLoginSession(response);
        this.refreshTokenService.scheduleRefreshToken(true);
        this.authStatusSource.next(true);
        return true;
      }),
      catchError((error: HttpErrorResponse) => throwError(error))
    );
  }

  logout(): void {
    const refreshToken = encodeURIComponent(
      this.tokenStoreService.getRawAuthToken(AuthTokenType.RefreshToken)
    );
    this.swagger
      .api_Account_Logout(refreshToken)
      .pipe(
        map(response => response || {}),
        catchError((error: HttpErrorResponse) => throwError(error)),
        finalize(() => {
          this.setUser(null);
          this.tokenStoreService.deleteAuthTokens();
          this.refreshTokenService.unscheduleRefreshToken(true);
          this.authStatusSource.next(false);
          this.router.navigate(['/login']);
        })
      )
      .subscribe(result => {
        console.log('logout', result);
      });
  }

  isAuthUserLoggedIn(): boolean {
    return (
      this.tokenStoreService.hasStoredAccessAndRefreshTokens() &&
      !this.tokenStoreService.isAccessTokenTokenExpired()
    );
  }

  isAuthUserHasRoles(requiredRoles: string[]): boolean {
    const user = this.user.value;
    if (!user || !user.userRoles) {
      return false;
    }

    return requiredRoles.some(requiredRole => {
      if (user.userRoles && user.userRoles.length > 0) {
        return (
          user.userRoles
            .map(role => role.roleName.toUpperCase())
            .indexOf(requiredRole.toUpperCase()) >= 0
        );
      } else {
        return false;
      }
    });
  }

  private updateStatusOnPageRefresh(): void {
    this.authStatusSource.next(this.isAuthUserLoggedIn());
  }
}
