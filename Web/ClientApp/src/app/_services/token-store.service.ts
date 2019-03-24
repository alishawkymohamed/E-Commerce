import { Injectable } from '@angular/core';
import * as jwt_decode from 'jwt-decode';

import { AuthTokenType } from '../_models/auth-token-type';
import { BrowserStorageService } from './browser-storage.service';
import { UtilsService } from './utils.service';
import { AccessToken } from './swagger/SwaggerClient.service';

@Injectable({
  providedIn: 'root'
})
export class TokenStoreService {
  constructor(
    private browserStorageService: BrowserStorageService,
    private utilsService: UtilsService
  ) {}

  getRawAuthToken(tokenType: AuthTokenType): string {
    return this.browserStorageService.getLocal(AuthTokenType[tokenType]);
  }

  getDecodedAccessToken(): any {
    return jwt_decode(this.getRawAuthToken(AuthTokenType.AccessToken));
  }

  getAuthUserDisplayName(): string {
    return this.getDecodedAccessToken().DisplayName;
  }

  getAccessTokenExpirationDateUtc(): Date | null {
    const decoded = this.getDecodedAccessToken();
    if (decoded.exp === undefined) {
      return null;
    }
    const date = new Date(0); // The 0 sets the date to the epoch
    date.setUTCSeconds(decoded.exp);
    return date;
  }

  isAccessTokenTokenExpired(): boolean {
    const expirationDateUtc = this.getAccessTokenExpirationDateUtc();
    if (!expirationDateUtc) {
      return true;
    }
    return !(expirationDateUtc.valueOf() > new Date().valueOf());
  }

  deleteAuthTokens() {
    this.browserStorageService.removeLocal(
      AuthTokenType[AuthTokenType.AccessToken]
    );
    this.browserStorageService.removeLocal(
      AuthTokenType[AuthTokenType.RefreshToken]
    );
  }

  setToken(tokenType: AuthTokenType, tokenValue: string): void {
    if (this.utilsService.isEmptyString(tokenValue)) {
      console.error(`${AuthTokenType[tokenType]} is null or empty.`);
    }

    if (
      tokenType === AuthTokenType.AccessToken &&
      this.utilsService.isEmptyString(tokenValue)
    ) {
      throw new Error("AccessToken can't be null or empty.");
    }

    this.browserStorageService.setLocal(AuthTokenType[tokenType], tokenValue);
  }

  getDecodedTokenRoles(): string[] | null {
    const decodedToken = this.getDecodedAccessToken();
    const roles =
      decodedToken[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];
    if (!roles) {
      return null;
    }

    if (Array.isArray(roles)) {
      return roles.map(role => role.toLowerCase());
    } else {
      return [roles.toLowerCase()];
    }
  }

  storeLoginSession(response: AccessToken): void {
    this.setToken(AuthTokenType.AccessToken, response['access_token']);
    this.setToken(AuthTokenType.RefreshToken, response['refresh_token']);
  }

  hasStoredAccessAndRefreshTokens(): boolean {
    const accessToken = this.getRawAuthToken(AuthTokenType.AccessToken);
    const refreshToken = this.getRawAuthToken(AuthTokenType.RefreshToken);
    return (
      !this.utilsService.isEmptyString(accessToken) &&
      !this.utilsService.isEmptyString(refreshToken)
    );
  }
}
