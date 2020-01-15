import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Orders } from '../shared/Orders';

@Injectable({
  providedIn: 'root'
})
export class SalesDataService {
  public url: string = 'https://localhost:5001/api/orders/';

  constructor(private http: HttpClient) { }

  getData(index:number, pageSize:number): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}${index}/${pageSize}`);
  }
}

