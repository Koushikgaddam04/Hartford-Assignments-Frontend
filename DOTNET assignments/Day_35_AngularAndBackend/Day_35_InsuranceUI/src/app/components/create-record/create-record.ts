import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Insurance } from '../../services/insurance';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-record',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-record.html',
})
export class CreateRecord {
  newPolicy = {
    policyNumber: '',
    type: 'Health',
    premium: 0,
    customerId: 1 // Default ID for G. Koushik
  };

  constructor(private service: Insurance, private router: Router) {}

  savePolicy() {
    this.service.createPolicy(this.newPolicy).subscribe({
      next: (res: any) => {
        alert('Policy Registered Successfully!');
        this.router.navigate(['/data']); // This takes you back to see the new record
      },
      error: (err: any) => {
        console.error('Failed to save:', err);
      }
    });
  }
}