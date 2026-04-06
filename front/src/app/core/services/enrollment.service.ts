import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({ providedIn: 'root' })
export class EnrollmentService {
  private url = `${environment.apiUrl}/enrollments`;

  constructor(private http: HttpClient) {}

  enroll(studentId: number, courseId: number): Observable<any> {
    return this.http.post<any>(this.url, { studentId, courseId });
  }

  getByStudent(studentId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}/student/${studentId}`);
  }

  unenroll(studentId: number, courseId: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/student/${studentId}/course/${courseId}`);
  }
}