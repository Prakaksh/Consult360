import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiCallService {
  requestHeader: any
  
  constructor(private http: HttpClient) {
  }


  post<T>(apiUrl: string, objKey: any): Observable<any> {
    this.setHeader();
    return this.http.post<any>(apiUrl, objKey, { 'headers': this.requestHeader, observe: 'response' });
  }

  get<T>(apiUrl: string): Observable<T> {
    this.setHeader();
    return this.http.get<T>(apiUrl, { 'headers': this.requestHeader });
  }


  delete(apiUrl: string, objKey: any): Observable<any> {
    this.setHeader();
    return this.http.delete<any>(apiUrl, { 'headers': this.requestHeader, observe: 'response' });
  }

  put(apiUrl: string, objKey: any): Observable<any> {
    this.setHeader();
    return this.http.post<any>(apiUrl, objKey, { 'headers': this.requestHeader, observe: 'response' });
  }

  postwithoutHeader<T>(apiUrl: string, objKey: any): Observable<any> {
    return this.http.post<any>(apiUrl, objKey, { observe: 'response' });
  }

  setHeader() {
    this.requestHeader =
      new HttpHeaders({ 'Authorization': `Bearer` });
  }
  getLocalStorageItem(key: string): any {
    return localStorage.getItem(key);
  }


  

}
