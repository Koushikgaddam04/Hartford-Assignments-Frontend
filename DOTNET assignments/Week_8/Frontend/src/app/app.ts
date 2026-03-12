import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Navbar } from './components/navbar/navbar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, Navbar],
  templateUrl: './app.html' // Ensure this matches your filename (app.html or app.component.html)
})
export class App {
  title = 'Week8_Frontend';

  // We inject PLATFORM_ID to detect if the code is running in a browser
  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

  isLoggedIn(): boolean {
    // This check prevents the 'localStorage is not defined' error during SSR/Prerendering
    if (isPlatformBrowser(this.platformId)) {
      return !!localStorage.getItem('token');
    }
    return false;
  }
}