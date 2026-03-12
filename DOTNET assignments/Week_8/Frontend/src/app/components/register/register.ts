import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Auth } from '../../services/auth';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.html'
})
export class Register {
  user = {
    fullName: '',
    email: '',
    password: '',
    role: 'Customer' // Default role for new signups
  };

  constructor(private auth: Auth, private router: Router) { }

  onRegister() {
    this.auth.register(this.user).subscribe({
      next: () => {
        alert('Registration Successful! You can now login.');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Registration failed', err);
        if (err.status === 0) {
          alert("Backend server is unreachable! Please ensure 'dotnet run' is running the API.");
        } else {
          alert(`Error during registration: ${err.error?.message || err.error || 'Please try again.'}`);
        }
      }
    });
  }
}