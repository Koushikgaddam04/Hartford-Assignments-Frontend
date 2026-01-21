import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from '../../interface/user';
import { CommonModule } from '@angular/common'; // Adding CommonModule is often helpful

@Component({
  selector: 'app-usercomponent',
  standalone: true, // Ensure standalone is true if you are importing directly
  imports: [FormsModule, CommonModule],
  templateUrl: './usercomponent.html',
  styleUrl: './usercomponent.css',
})
export class Usercomponent {
  users: User[] = [];
  user: User = {
    id: 0,
    name: '',
    email: ''
  };

  isEditMode = false;

  saveUser() {
    if (this.isEditMode) {
      const index = this.users.findIndex((u) => u.id === this.user.id);
      if (index !== -1) {
        this.users[index] = { ...this.user };
      }
      this.isEditMode = false;
    } else {
      // Create a copy with a new ID
      const newUser = { ...this.user, id: Date.now() };
      this.users.push(newUser);
    }
    this.resetForm();
  }

  editUser(selectedUser: User) {
    // Create a copy so editing doesn't affect the table list instantly
    this.user = { ...selectedUser };
    this.isEditMode = true;
  }

  deleteUser(id: number) {
    this.users = this.users.filter((u) => u.id !== id);
  }

  resetForm() {
    this.user = { id: 0, name: '', email: '' };
    this.isEditMode = false;
  }
}