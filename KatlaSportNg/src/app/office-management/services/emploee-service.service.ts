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

  getEmployee(employeeId: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.url}${employeeId}`);
  }

  addEmployee(office: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this.url}`,office);
  }

  updateEmployee(office: Employee): Observable<Object> {
    return this.http.put<Employee>(`${this.url}${office.officeId}`,office);
  }

  deleteEmployee(officeId: number): Observable<Object> {
    return this.http.delete(`${this.url}${officeId}`);
  }
}
