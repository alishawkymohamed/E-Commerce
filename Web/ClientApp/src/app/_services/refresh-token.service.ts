import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders
} from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Subscription, throwError, timer } from 'rxjs/index';
import { catchError, map } from 'rxjs/operators';

import { AuthTokenType } from '../_models/auth-token-type';
import {
  AccessToken,
  API_BASE_URL,
  SwaggerClient
} from './swagger/SwaggerClient.service';
import { BrowserStorageService } from './browser-storage.service';
import { TokenStoreService } from './token-store.service';
import { UtilsService } from './utils.service';

@Injectable({
  providedIn: 'root'
})
export class RefreshTokenService {
  private refreshTokenTimerCheckId = 'is_refreshToken_timer_started';
  private refreshTokenSubscription: Subscription | null = null;

  constructor(
    private tokenStoreService: TokenStoreService,
    @Inject(API_BASE_URL) private baseUrl: string,
    private swagger: SwaggerClient,
    private http: HttpClient,
    private browserStorageService: BrowserStorageService,
    private utilsService: UtilsService
  ) {}

  scheduleRefreshToken(isAuthUserLoggedIn: boolean) {
    this.unscheduleRefreshToken(false);

    if (!isAuthUserLoggedIn) {
      return;
    }

    if (this.isRefreshTokenTimerStartedInAnotherTab()) {
      return;
    }

    const expDateUtc = this.tokenStoreService.getAccessTokenExpirationDateUtc();
    if (!expDateUtc) {
      throw new Error('This access token has not the `exp` property.');
    }
    const expiresAtUtc = expDateUtc.valueOf();
    const nowUtc = new Date().valueOf();
    const threeSeconds = 3000;
    const initialDelay = Math.max(1, expiresAtUtc - nowUtc - threeSeconds);
    console.log('Initial scheduleRefreshToken Delay(ms)', initialDelay);
    const timerSource$ = timer(initialDelay);
    this.refreshTokenSubscription = timerSource$.subscribe(() => {
      this.refreshToken(isAuthUserLoggedIn);
    });

    this.setRefreshTokenTimerStarted();
  }

  unscheduleRefreshToken(cancelTimerCheckToken: boolean) {
    if (this.refreshTokenSubscription) {
      this.refreshTokenSubscription.unsubscribe();
    }

    if (cancelTimerCheckToken) {
      this.deleteRefreshTokenTimerCheckId();
    }
  }

  private refreshToken(isAuthUserLoggedIn: boolean) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const model = {
      refreshToken: this.tokenStoreService.getRawAuthToken(
        AuthTokenType.RefreshToken
      )
    };
    return this.swagger
      .api_Account_RefreshToken(model)
      .pipe(
        map(response => response || {}),
        catchError((error: HttpErrorResponse) => throwError(error))
      )
      .subscribe(result => {
        console.log('RefreshToken Result', result);
        this.tokenStoreService.storeLoginSession(<AccessToken>result);
        this.deleteRefreshTokenTimerCheckId();
        this.scheduleRefreshToken(isAuthUserLoggedIn);
      });
  }

  private isRefreshTokenTimerStartedInAnotherTab(): boolean {
    const currentTabId = this.utilsService.getCurrentTabId();
    const timerStat = this.browserStorageService.getLocal(
      this.refreshTokenTimerCheckId
    );
    console.log('RefreshTokenTimer Check', {
      refreshTokenTimerCheckId: timerStat,
      currentTabId: currentTabId
    });
    const isStarted =
      timerStat &&
      timerStat.isStarted === true &&
      timerStat.tabId !== currentTabId;
    if (isStarted) {
      console.log(`RefreshToken timer has already been started in another tab with tabId=${
        timerStat.tabId
      }.
      currentTabId=${currentTabId}.`);
    }
    return isStarted;
  }

  private setRefreshTokenTimerStarted(): void {
    this.browserStorageService.setLocal(this.refreshTokenTimerCheckId, {
      isStarted: true,
      tabId: this.utilsService.getCurrentTabId()
    });
  }

  private deleteRefreshTokenTimerCheckId() {
    this.browserStorageService.removeLocal(this.refreshTokenTimerCheckId);
  }
}
