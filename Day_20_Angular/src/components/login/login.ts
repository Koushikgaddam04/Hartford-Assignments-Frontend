import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html'
})
export class LoginComponent {
  userObj: any = { EmailId: '', Password: '' };
  router = inject(Router);

  onLogin() {
    if (this.userObj.EmailId == "admin" && this.userObj.Password == "1234") {
      localStorage.setItem('loginUser', this.userObj.EmailId);
      this.router.navigateByUrl('add-emp');
    } else {
      alert('Wrong Credentials');
    }
  }
}