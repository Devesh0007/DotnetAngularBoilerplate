import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ILoginDetails, ILoginResponse } from 'src/app/@core/interfaces/login.interface';
import { SessionStorageEnum } from 'src/app/@core/enums/session-storage';

@Injectable({ providedIn: 'root' })
export class AuthService {
  url = environment.apiBaseUrl;
  headers = new HttpHeaders({'Content-Type':'application/json'});

  constructor(private _httpClient: HttpClient) { 
  }

  registerUser() {
    const params = {};
    return this._httpClient.post('url', params).pipe(catchError(this.handleError));
  }

  login(loginDetails: ILoginDetails): Observable<ILoginResponse> {
    return this._httpClient
      .post<ILoginResponse>((this.url + 'Auth/Login'), JSON.stringify(loginDetails), {headers: this.headers});
  }

  isLoggedIn() {
    const token = sessionStorage.getItem(SessionStorageEnum.AccessToken);
    if(token && token != ''){
      const expiresOn = parseInt(sessionStorage.getItem(SessionStorageEnum.ExpiresOn) ?? '0'); // get expiresOn from session storage
      const utcDate = Date.parse(new Date(new Date().toUTCString()).toString())
      const isValid = expiresOn > utcDate;
      return isValid;
    }
    return false;
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}