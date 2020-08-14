import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { throwError } from 'rxjs/internal/observable/throwError';
import { Observable } from 'rxjs';
import {tap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ArbitrageData } from '../models/bitcoinArbitrage.models';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getFirst100(): Observable<Array<ArbitrageData>> {
    return this.httpClient.get<Array<ArbitrageData>>(environment.apiUrl + 'getLatest100').pipe(
        tap(),
        catchError(this.handleError)
    );
  }
  public getFirst1000(): Observable<Array<ArbitrageData>> {
    return this.httpClient.get<Array<ArbitrageData>>(environment.apiUrl + 'getLatest1000').pipe(
        tap(),
        catchError(this.handleError)
    );
  }
  public getFirst10000(): Observable<Array<ArbitrageData>> {
    return this.httpClient.get<Array<ArbitrageData>>(environment.apiUrl + 'getLatest10000').pipe(
        tap(),
        catchError(this.handleError)
    );
  }
  public getFirst100000(): Observable<Array<ArbitrageData>> {
    return this.httpClient.get<Array<ArbitrageData>>(environment.apiUrl + 'getLatest100000').pipe(
        tap(),
        catchError(this.handleError)
    );
  }
  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occured: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
