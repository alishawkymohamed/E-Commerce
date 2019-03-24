import { Injectable } from '@angular/core';
import { Encrypt, Decrypt } from '../Utility/app.Encryption';

@Injectable({
  providedIn: 'root'
})
export class BrowserStorageService {
  getSession(key: string): any {
    const data = window.sessionStorage.getItem(key);
    if (data) {
      return JSON.parse(data);
    } else {
      return null;
    }
  }

  setSession(key: string, value: any): void {
    const data = value === undefined ? '' : JSON.stringify(value);
    window.sessionStorage.setItem(Encrypt(key), Encrypt(data));
  }

  removeSession(key: string): void {
    window.sessionStorage.removeItem(Encrypt(key));
  }

  removeAllSessions(): void {
    for (const key in window.sessionStorage) {
      if (window.sessionStorage.hasOwnProperty(key)) {
        this.removeSession(key);
      }
    }
  }

  getLocal(key: string): any {
    const data = window.localStorage.getItem(Encrypt(key));
    if (data) {
      return JSON.parse(Decrypt(data));
    } else {
      return null;
    }
  }

  setLocal(key: string, value: any): void {
    const data = value === undefined ? '' : JSON.stringify(value);
    window.localStorage.setItem(Encrypt(key), Encrypt(data));
  }

  removeLocal(key: string): void {
    window.localStorage.removeItem(Encrypt(key));
  }

  removeAllLocals(): void {
    for (const key in window.localStorage) {
      if (window.localStorage.hasOwnProperty(key)) {
        this.removeLocal(key);
      }
    }
    window.localStorage.clear();
  }

  getKeys = function(): string[] {
    let Keys = [];
    for (let i = 0, len = localStorage.length; i < len; ++i) {
      Keys.push(Decrypt(localStorage.key(i)));
    }
    return Keys;
  };
}
