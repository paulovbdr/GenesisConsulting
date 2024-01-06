import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CdbModel } from './interface/cdb-model';
import { CdbResultModel } from './interface/cdb-result-model';
import { finalize, Observable } from 'rxjs';

const urlBase = 'http://localhost:57790/api';

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

  calculateInvestment(cdb: CdbModel): Observable<CdbResultModel> {
    return this.http.post<any>(`${urlBase}/Cdb/CalculateInvestment`, cdb, httpOptions).pipe(
      finalize(() => {
        console.log('retorno do post');
      })
    );
  }
}
