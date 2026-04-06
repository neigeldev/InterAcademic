import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { StudentService } from '../../core/services/student.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  name  = '';
  email = '';
  error = '';

  constructor(
    private studentService: StudentService,
    private router: Router
  ) {}

  register() {
    if (!this.name || !this.email) {
      this.error = 'Todos los campos son obligatorios.';
      return;
    }

    this.studentService.create({ name: this.name, email: this.email }).subscribe({
      next: () => this.router.navigate(['/login']),
      error: (err) => this.error = err.error?.message || 'Error al registrar.'
    });
  }
}