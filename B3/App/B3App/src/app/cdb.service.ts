import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Cdb } from './interface/cdb';
import { finalize, Observable } from 'rxjs';

const urlBase = 'http://localhost:57790';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Method': 'DELETE, POST, GET, OPTIONS',
    'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With'
  }),
};

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private http: HttpClient) { }

  getTest(): Observable<Cdb> {
    console.log(`${urlBase}/WeatherForecast`);
    return this.http.get<any>(`${urlBase}/WeatherForecast`).pipe(
      finalize(() => {
        console.log('retorno do get');
      })
    );
  }
}
