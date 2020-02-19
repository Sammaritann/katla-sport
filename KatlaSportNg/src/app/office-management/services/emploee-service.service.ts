import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import {Employee} from '../models/emploee'

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url = environment.apiUrl + 'api/staff/';


  constructor(private http: HttpClient) { }

  getStaf(): Observable<Array<Employee>> {
    return this.http.get<Array<Employee>>(this.url);
  }

  getOfficeStaf(officeId:number): Observable<Array<Employee>> {
    return this.http.get<Array<Employee>>(`${this.url}${officeId}/office`);
  }

  getEmployee(employeeId: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.url}${employeeId}`);
  }

  addEmployee(emploee: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this.url}`,emploee);
  }

  updateEmployee(emploee: Employee): Observable<Object> {
    return this.http.put<Employee>(`${this.url}${emploee.id}`,emploee);
  }

  deleteEmployee(emploee: number): Observable<Object> {
    return this.http.delete(`${this.url}${emploee}`);
  }
}
