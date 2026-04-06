import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CourseService } from '../../core/services/course.service';
import { EnrollmentService } from '../../core/services/enrollment.service';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-courses',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './courses.html',
  styleUrl: './courses.css'
})
export class Courses implements OnInit {
  courses: any[]     = [];
  selected: number[] = [];
  error              = '';
  loading            = false;

  constructor(
    private courseService:     CourseService,
    private enrollmentService: EnrollmentService,
    private authService:       AuthService,
    private router:            Router
  ) {}

  ngOnInit() {
    this.courseService.getAll().subscribe({
      next: (data) => this.courses = data,
      error: ()     => this.error  = 'Error al cargar las materias.'
    });
  }

  isSelected(courseId: number): boolean {
    return this.selected.includes(courseId);
  }

  getSelectedCourses(): any[] {
    return this.courses.filter(c => this.selected.includes(c.id));
  }

  toggleCourse(courseId: number) {
    if (this.isSelected(courseId)) {
      this.selected = this.selected.filter(id => id !== courseId);
      this.error    = '';
      return;
    }

    if (this.selected.length >= 3) {
      this.error = 'Solo puedes seleccionar 3 materias.';
      return;
    }

    // Validar mismo profesor en el frontend
    const course          = this.courses.find(c => c.id === courseId);
    const selectedCourses = this.getSelectedCourses();
    const sameTeacher     = selectedCourses.some(c => c.teacherName === course.teacherName);

    if (sameTeacher) {
      this.error = `Ya tienes una materia con ${course.teacherName}.`;
      return;
    }

    this.selected.push(courseId);
    this.error = '';
  }

  get totalCredits(): number {
    return this.selected.length * 3;
  }

  confirm() {
    if (this.selected.length !== 3) {
      this.error = 'Debes seleccionar exactamente 3 materias.';
      return;
    }

    const studentId = this.authService.getStudentId();
    this.loading    = true;
    this.error      = '';

    const enrollments = this.selected.map(courseId =>
      this.enrollmentService.enroll(studentId, courseId).toPromise()
    );

    Promise.all(enrollments)
      .then(() => this.router.navigate(['/dashboard']))
      .catch((err) => {
        this.error   = err.error?.message || 'Error al inscribir materias.';
        this.loading = false;
      });
  }

  cancel() {
    this.selected = [];
    this.error    = '';
  }
}