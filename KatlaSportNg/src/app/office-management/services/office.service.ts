import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Office } from '../models/office';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  private url = environment.apiUrl + 'api/offices/';
  constructor(private http:HttpClient) { }

  getOffices(): Observable<Array<Office>> {
    return this.http.get<Array<Office>>(this.url);
  }

  getOffice(officeId: number): Observable<Office> {
    return this.http.get<Office>(`${this.url}${officeId}`);
  }

  addOffice(office: Office): Observable<Office> {
    return this.http.post<Office>(`${this.url}`,office);
  }

  updateOffice(office: Office): Observable<Object> {
    return this.http.put<Office>(`${this.url}${office.officeId}`,office);
  }

  deleteOffice(officeId: number): Observable<Object> {
    return this.http.delete(`${this.url}${officeId}`);
  }
}
