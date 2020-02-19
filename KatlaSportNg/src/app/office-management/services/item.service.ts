import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Item } from '../models/item';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private url = environment.apiUrl + 'api/items/';
  constructor(private http:HttpClient) { }

  getItems(): Observable<Array<Item>> {
    return this.http.get<Array<Item>>(this.url);
  }

  getOfficeItems(officeId:number): Observable<Array<Item>> {
    return this.http.get<Array<Item>>(`${this.url}${officeId}/office`);
  }

  getDescendantItems(parentId:number): Observable<Array<Item>> {
    return this.http.get<Array<Item>>(`${this.url}${parentId}/descendant`);
  }

  getItem(itemId: number): Observable<Item> {
    return this.http.get<Item>(`${this.url}${itemId}`);
  }

  addItem(item: Item): Observable<Item> {
    return this.http.post<Item>(`${this.url}`,item);
  }

  addChildItem(item: Item,parentId:number): Observable<Item> {
    return this.http.post<Item>(`${this.url}${parentId}`,item);
  }

  updateItem(item: Item): Observable<Object> {
    return this.http.put<Item>(`${this.url}${item.id}`,item);
  }

  deleteItem(itemId: number): Observable<Object> {
    return this.http.delete(`${this.url}${itemId}`);
  }
}
