import { SelectItem } from 'primeng/api';
import { Encrypt, Decrypt } from './app.Encryption';

// tslint:disable-next-line:eofline
const LocalStorage = window.localStorage;

const setItem = function(key: string, value: string) {
  LocalStorage.setItem(Encrypt(key), Encrypt(value));
};

const getItem = function(key: string): string {
  return Decrypt(LocalStorage.getItem(Encrypt(key)));
};

const removeItem = function(key: string) {
  LocalStorage.removeItem(Encrypt(key));
};

const clear = function() {
  LocalStorage.clear();
};

const getKeys = function(): string[] {
  let Keys = [];
  for (let i = 0, len = localStorage.length; i < len; ++i) {
    Keys.push(Decrypt(localStorage.key(i)));
  }
  return Keys;
};

export { SelectItem, getItem, removeItem, clear, getKeys };
