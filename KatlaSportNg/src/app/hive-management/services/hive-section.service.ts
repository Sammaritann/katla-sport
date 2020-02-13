import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { HiveSection } from '../models/hive-section';
import { HiveSectionListItem } from '../models/hive-section-list-item';

@Injectable({
  providedIn: 'root'
})
export class HiveSectionService {
  private url = environment.apiUrl + 'api/sections/';

  constructor(private http: HttpClient) { }

  getHiveSections(): Observable<Array<HiveSectionListItem>> {
    return this.http.get<Array<HiveSectionListItem>>(this.url);
  }

  getHiveSection(hiveSectionId: number): Observable<HiveSection> {
    return this.http.get<HiveSection>(`${this.url}${hiveSectionId}`);
  }

  addHiveSection(hive: HiveSection): Observable<HiveSection> {
    return this.http.post<HiveSection>(`${this.url}`,hive);
  }

  updateHiveSection(hive: HiveSection): Observable<Object> {
    return this.http.put<HiveSection>(`${this.url}${hive.id}`,hive);
  }

  deleteHiveSection(hiveId: number): Observable<Object> {
    return this.http.delete(`${this.url}${hiveId}`);
  }

  setHiveSectionStatus(hiveSectionId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put(`${this.url}${hiveSectionId}/status/${deletedStatus}`,null);
  }
}
