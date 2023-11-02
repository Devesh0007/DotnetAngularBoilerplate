import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { apiBaseUrl } from 'src/environments/environment';
import { ILoginDetails as ILoginUserDetails, ILoginResponse as ILoginUserResponse, IRegisterUserDetails, IRegisterUserResponse } from 'src/app/@core/interfaces/login.interface';
import { SessionStorageEnum } from 'src/app/@core/enums/session-storage';

@Injectable({ providedIn: 'root' })
export class AuthService {
  url = apiBaseUrl;
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private _httpClient: HttpClient) {
  }

  registerUser(registerUserDetails: IRegisterUserDetails): Observable<IRegisterUserResponse> {
    return this._httpClient
      .post<IRegisterUserResponse>((this.url + 'api/Auth/Login'), JSON.stringify(registerUserDetails), { headers: this.headers });
  }

  login(loginUserDetails: ILoginUserDetails): Observable<ILoginUserResponse> {
    return this._httpClient
      .post<ILoginUserResponse>((this.url + 'api/Auth/Login'), JSON.stringify(loginUserDetails), { headers: this.headers });
  }

  isLoggedIn() {
    const token = sessionStorage.getItem(SessionStorageEnum.AccessToken);
    if (token && token != '') {
      const expiresOn = parseInt(sessionStorage.getItem(SessionStorageEnum.ExpiresOn) ?? '0'); // get expiresOn from session storage
      const utcDate = Date.parse(new Date(new Date().toUTCString()).toString())
      return expiresOn > utcDate;
    }
    return false;
  }

  getLoginDetails(token: string){
    this.headers = this.headers.append("Authorization", "Bearer "+ token);
    return this._httpClient
    .get<ILoginUserResponse>((this.url + 'api/Auth/GetLoggedInUserDetails'), { headers: this.headers })
  }
}