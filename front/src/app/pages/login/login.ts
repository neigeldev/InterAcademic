import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  email = '';
  error = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  login() {
    if (!this.email) {
      this.error = 'El correo es obligatorio.';
      return;
    }

    this.authService.login(this.email).subscribe({
      next: () => this.router.navigate(['/courses']),
      error: (err) => this.error = err.error?.message || 'Estudiante no encontrado.'
    });
  }
}