import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private url = `${environment.apiUrl}/auth`;

  constructor(private http: HttpClient) {}

  login(email: string): Observable<any> {
    return this.http.post<any>(`${this.url}/login`, { email }).pipe(
      tap(response => {
        localStorage.setItem('token',     response.token);
        localStorage.setItem('studentId', response.studentId.toString());
        localStorage.setItem('name',      response.name);
      })
    );
  }

  logout(): void {
    localStorage.clear();
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getStudentId(): number {
    return parseInt(localStorage.getItem('studentId') || '0');
  }

  getName(): string {
    return localStorage.getItem('name') || '';
  }
}