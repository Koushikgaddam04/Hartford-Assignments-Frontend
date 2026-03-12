import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Auth } from '../../services/auth';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.html'
})
export class Login implements OnInit {
  generatedCaptcha: string = '';
  loginData = {
    email: '',
    password: '',
    userCaptcha: '',
    actualCaptcha: ''
  };

  constructor(private auth: Auth, private router: Router) { }

  ngOnInit() {
    this.generateNewCaptcha();
  }

  generateNewCaptcha() {
    this.generatedCaptcha = Math.random().toString(36).substring(2, 8).toUpperCase();
    this.loginData.actualCaptcha = this.generatedCaptcha;
  }

  onLogin() {
    // 1. First, check the CAPTCHA locally
    const userCaptchaInput = this.loginData.userCaptcha.toUpperCase().trim();
    if (userCaptchaInput !== this.loginData.actualCaptcha) {
      alert("CAPTCHA does not match! Please try again.");
      this.generateNewCaptcha();
      return;
    }

    // Ensure we send the correctly cased captcha back
    this.loginData.userCaptcha = userCaptchaInput;

    // 2. If CAPTCHA is correct, hit the API
    this.auth.login(this.loginData).subscribe({
      next: (res: any) => {
        if (!res || !res.user || !res.user.role) {
          alert("Login successful but no user role received. Please contact support.");
          return;
        }

        const role = res.user.role.toLowerCase();

        if (role === 'admin') {
          this.router.navigate(['/admin-dashboard']);
        } else if (role === 'agent') {
          this.router.navigate(['/agent-dashboard']);
        } else {
          this.router.navigate(['/customer-dashboard']);
        }
      },
      error: (err) => {
        console.error("Login Error:", err);
        if (err.status === 0) {
          alert("Backend server is unreachable! Please ensure 'dotnet run' is running the API.");
        } else {
          alert(`Login failed! ${err.error || 'Invalid credentials.'}`);
        }
        this.generateNewCaptcha();
        this.loginData.userCaptcha = '';
        this.loginData.password = '';
      }
    });
  }
}