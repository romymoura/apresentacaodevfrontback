import { Injectable } from '@angular/core';
import { AppConstants } from '../app.contants';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public token: string;
  public username: string;

  constructor(
    private http: HttpClient
  ) { }


  public sigin(username: string, password: string): Observable<any> {
    return this.http.post<any>(environment.ApiAuth, {
      username,
      password
    });
  }
  public sigOut() {
    localStorage.removeItem(AppConstants.TokenLocalStorageKey);
    localStorage.removeItem(AppConstants.TokenLocalStorageUsername);
    this.token = null;
    this.username = null;
  }



  public isAuthorized(): boolean {
    let authorized = this.token != null;
    if (!authorized) {
      const token = localStorage.getItem(AppConstants.TokenLocalStorageKey);
      if (token != null && token !== '' && token !== undefined) {
        this.token = token;
        authorized = this.token != null;
      }
    }
    return authorized;
  }

  public saveToken(token: string, username: string): void {
    localStorage.setItem(AppConstants.TokenLocalStorageKey, token);
    localStorage.setItem(AppConstants.TokenLocalStorageUsername, username);
    this.token = token;
    this.username = username;
  }

  public getToken(): string {
    const tk = localStorage.getItem(AppConstants.TokenLocalStorageKey);
    return tk;
  }

  public getUsername(): string {
    const username = localStorage.getItem(AppConstants.TokenLocalStorageUsername);
    return username === null ? 'Logar' : username ;
  }
}
