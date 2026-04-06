import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({ providedIn: 'root' })
export class CourseService {
  private url = `${environment.apiUrl}/courses`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.url);
  }

  getById(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/${id}`);
  }
}