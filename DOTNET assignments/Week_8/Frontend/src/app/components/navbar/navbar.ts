import { Component, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { Auth } from '../../services/auth';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar.html'
})
export class Navbar implements OnInit {
  userName: string = '';
  userRole: string = '';

  constructor(
    private auth: Auth, 
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  ngOnInit() {
    // Only run this logic if we are in the browser
    if (isPlatformBrowser(this.platformId)) {
      const userData = JSON.parse(localStorage.getItem('user') || '{}');
      this.userName = userData.fullName || 'User';
      this.userRole = userData.role || '';
    }
  }

  onLogout() {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}