import { AuthService } from './auth/auth.service';
import { AirplaneModel } from './airplane/airplane.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AirplaneService {

  constructor(private http: HttpClient, private authService: AuthService) { }


  deleteAirplane(id: number): Observable<any> {
    if ( this.authService.isAuthorized() ) {
      const token = ('Bearer ' + this.authService.getToken());
      let httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
      httpHeaders = httpHeaders.append('Authorization', token);
      httpHeaders.append('Authorization', token);
      const options = {
          headers: httpHeaders
      };
      console.log(token);
      const url = environment.ApiAirplaneDelete + id;
      return this.http.delete(url, options);
    }
  }

  createAirplane(airplane: AirplaneModel): Observable<any> {
    if ( this.authService.isAuthorized() ) {
      const token = ('Bearer ' + this.authService.getToken());
      let httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
      httpHeaders = httpHeaders.append('Authorization', token);
      httpHeaders.append('Authorization', token);
      const options = {
          headers: httpHeaders
      };
      console.log(token);
      return this.http.post<any>(environment.ApiAirplaneCreate, airplane, options);
    }
  }

  getAll(): Observable<any> {
    if ( this.authService.isAuthorized() ) {
      const token = ('Bearer ' + this.authService.getToken());
      let httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
      httpHeaders = httpHeaders.append('Authorization', token);
      httpHeaders.append('Authorization', token);
      const options = {
          headers: httpHeaders
      };
      console.log(token);
      return this.http.get<any>(environment.ApiAirplaneGetAll, options);
    }
  }

  getAirplane(input: AirplaneModel): Observable<any> {
    if ( this.authService.isAuthorized() ) {
      const token = ('Bearer ' + this.authService.getToken());
      let httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
      httpHeaders = httpHeaders.append('Authorization', token);
      httpHeaders.append('Authorization', token);
      const options = {
          headers: httpHeaders
      };
      console.log(token);
      // tslint:disable-next-line:max-line-length
      return this.http.get<any>(`${environment.ApiAirplaneGet}?Id=${input.id}&CodeAirplane=${input.codeAirplane}&CountPassengers=${input.countPassengers}&DateRegister=${input.dateRegister}`, options);
    }
  }
}
