import * as CryptoJS from 'crypto-js';
import { environment } from 'src/environments/environment';

const iv = CryptoJS.enc.Hex.parse(environment.EncryptIV);
const Pass = CryptoJS.enc.Utf8.parse(environment.EncryptPassword);
const Salt = CryptoJS.enc.Utf8.parse(environment.EncryptSalt);
const key = CryptoJS.PBKDF2(Pass.toString(CryptoJS.enc.Utf8), Salt, {
  keySize: 128 / 32,
  iterations: 1000
});

const cfg = {
  mode: CryptoJS.mode.CBC,
  iv,
  padding: CryptoJS.pad.Pkcs7
};

// tslint:disable-next-line:only-arrow-functions
const Encrypt = function(params: string): string {
  return CryptoJS.AES.encrypt(params, key, cfg).toString();
};

// tslint:disable-next-line:only-arrow-functions
const Decrypt = function(params: string): string {
  return CryptoJS.AES.decrypt(params, key, cfg).toString(CryptoJS.enc.Utf8);
};

export { Encrypt, Decrypt };
