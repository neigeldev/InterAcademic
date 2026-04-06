import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { StudentService } from '../../core/services/student.service';
import { EnrollmentService } from '../../core/services/enrollment.service';
import { AuthService } from '../../core/services/auth.service';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './students.html',
  styleUrl: './students.css'
})
export class Students implements OnInit {
  students:         any[] = [];
  selectedStudent:  any   = null;
  enrollments:      any[] = [];
  classmates:       any   = {};
  currentStudentId: number = 0;

  editing   = false;
  editName  = '';
  editEmail = '';
  error     = '';

  constructor(
    private studentService:    StudentService,
    private enrollmentService: EnrollmentService,
    private authService:       AuthService,
    private router:            Router
  ) {}

  ngOnInit() {
    this.currentStudentId = this.authService.getStudentId();
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getAll().subscribe({
      next: (data) => {
        this.students = data;
        const current = data.find((s: any) => s.id === this.currentStudentId);
        if (current) this.selectStudent(current);
      }
    });
  }

  selectStudent(student: any) {
    this.selectedStudent = student;
    this.enrollments     = [];
    this.classmates      = {};
    this.editing         = false;
    this.error           = '';

    this.enrollmentService.getByStudent(student.id).subscribe({
      next: (data) => {
        this.enrollments = data;
        data.forEach((enrollment: any) => {
          this.loadClassmates(enrollment.courseId);
        });
      }
    });
  }

  loadClassmates(courseId: number) {
    const url = `${environment.apiUrl}/classmates/course/${courseId}`;
    fetch(url, {
      headers: { Authorization: `Bearer ${this.authService.getToken()}` }
    })
      .then(r => r.json())
      .then(data => this.classmates[courseId] = data)
      .catch(() => this.classmates[courseId] = []);
  }

  startEdit() {
    this.editing   = true;
    this.editName  = this.selectedStudent.name;
    this.editEmail = this.selectedStudent.email;
    this.error     = '';
  }

  cancelEdit() {
    this.editing = false;
    this.error   = '';
  }

  saveEdit() {
    if (!this.editName || !this.editEmail) {
      this.error = 'Todos los campos son obligatorios.';
      return;
    }

    this.studentService.update(this.selectedStudent.id, {
      name:  this.editName,
      email: this.editEmail
    }).subscribe({
      next: (updated) => {
        this.editing = false;
        this.error   = '';
        if (this.selectedStudent.id === this.currentStudentId) {
          localStorage.setItem('name', updated.name);
        }
        this.loadStudents();
      },
      error: (err) => this.error = err.error?.message || 'Error al actualizar.'
    });
  }

  deleteStudent() {
    if (!confirm(`¿Estás seguro de eliminar a ${this.selectedStudent.name}?`)) return;

    this.studentService.delete(this.selectedStudent.id).subscribe({
      next: () => {
        if (this.selectedStudent.id === this.currentStudentId) {
          this.authService.logout();
          this.router.navigate(['/login']);
        } else {
          this.selectedStudent = null;
          this.loadStudents();
        }
      },
      error: (err) => this.error = err.error?.message || 'Error al eliminar.'
    });
  }

  newRegister() {
    this.router.navigate(['/register']);
  }

  get totalCredits(): number {
    return this.enrollments.length * 3;
  }
}