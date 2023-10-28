import { Injectable } from '@angular/core';
import { SessionStorageEnum } from 'src/app/@core/enums/session-storage';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn() {
    const token = sessionStorage.getItem(SessionStorageEnum.AccessToken);
    if( token && token != ''){
      const expiresOn = parseInt(sessionStorage.getItem(SessionStorageEnum.ExpiresOn) ?? '0'); // get expiresOn from session storage
      const utcDate = Date.parse(new Date(new Date().toUTCString()).toString())
      return expiresOn > utcDate;
    }
    return false;
  }
  
}
