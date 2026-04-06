import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({ providedIn: 'root' })
export class StudentService {
  private url = `${environment.apiUrl}/students`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.url);
  }

  getById(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/${id}`);
  }

  create(data: { name: string; email: string }): Observable<any> {
    return this.http.post<any>(this.url, data);
  }

  update(id: number, data: { name: string; email: string }): Observable<any> {
    return this.http.put<any>(`${this.url}/${id}`, data);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}