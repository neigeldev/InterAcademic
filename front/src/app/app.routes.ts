import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login',      loadComponent: () => import('./pages/login/login').then(m => m.Login) },
  { path: 'register',   loadComponent: () => import('./pages/register/register').then(m => m.Register) },
  { path: 'courses',    loadComponent: () => import('./pages/courses/courses').then(m => m.Courses),         canActivate: [authGuard] },
  { path: 'my-courses', loadComponent: () => import('./pages/my-courses/my-courses').then(m => m.MyCourses), canActivate: [authGuard] },
  { path: 'students',   loadComponent: () => import('./pages/students/students').then(m => m.Students),      canActivate: [authGuard] },
  { path: 'classmates', loadComponent: () => import('./pages/classmates/classmates').then(m => m.Classmates),canActivate: [authGuard] },
  { path: 'dashboard', loadComponent: () => import('./pages/students/students').then(m => m.Students), canActivate: [authGuard] },
  { path: '**',         redirectTo: 'login' }
];