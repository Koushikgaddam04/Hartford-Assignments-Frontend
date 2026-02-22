import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  username = '';
  password = '';
  captcha = '';
  errorMessage = '';

  generatedCaptcha = Math.random().toString(36).substring(2, 8).toUpperCase();

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    if (this.captcha !== this.generatedCaptcha) {
      this.errorMessage = 'Invalid CAPTCHA.';
      this.generatedCaptcha = Math.random().toString(36).substring(2, 8).toUpperCase();
      this.captcha = '';
      return;
    }

    this.authService.login({ username: this.username, password: this.password, captcha: this.captcha })
      .subscribe({
        next: (res) => {
          if (res.role === 'Admin') this.router.navigate(['/admin']);
          else if (res.role === 'Agent') this.router.navigate(['/agent']);
          else this.router.navigate(['/customer']);
        },
        error: (err) => {
          this.errorMessage = err.error || 'Login failed.';
        }
      });
  }
}
