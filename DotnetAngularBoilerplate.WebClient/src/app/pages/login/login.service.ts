import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class LoginService {
  url = environment.apiBaseUrl;
  //httpOptions: HttpHeaders;
  constructor(private _httpClient: HttpClient) { 
    // Http Options
    // _httpClient.h = {
    //   headers: new HttpHeaders({
    //     'Content-Type': 'application/json'
    //   })
  }

  registerUser() {
    const params = {};
    return this._httpClient.post('url', params).pipe(catchError(this.handleError));
  }

  login(email: string, password: string) {
    const params = { email: email, password: password };
    const headers = new HttpHeaders({'Content-Type':'application/json'});
    //const headers = new HttpHeaders({'Content-Type':'application/json'});
    return this._httpClient.post((this.url + 'Auth/Login'), JSON.stringify(params), {headers: headers}).pipe(catchError(this.handleError));
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