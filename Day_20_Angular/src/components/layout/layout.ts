import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './layout.html'
})
export class LayoutComponent {
  loggedUserData: any;
  router = inject(Router);

  constructor() {
    const data = localStorage.getItem("loginUser");
    if (data != null) { this.loggedUserData = data; }
  }

  logoff() {
    localStorage.removeItem('loginUser');
    this.router.navigateByUrl('login');
  }
}