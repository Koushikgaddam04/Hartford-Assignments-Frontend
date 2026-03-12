import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Insurance } from '../../services/insurance';

@Component({
  selector: 'app-customer-dash',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customer-dash.html'
})
export class CustomerDash implements OnInit {
  myPolicies: any[] = [];
  newPolicy = {
    policyNumber: '',
    type: 'Life',
    premium: 0
  };

  constructor(private insurance: Insurance, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.loadMyPolicies();
  }

  loadMyPolicies() {
    this.insurance.getCustomerPolicies().subscribe({
      next: (res) => {
        this.myPolicies = res;
        this.cdr.detectChanges();
      },
      error: (err) => console.error(err)
    });
  }

  onCreatePolicy() {
    this.insurance.createPolicy(this.newPolicy).subscribe({
      next: () => {
        alert('Policy created successfully!');
        this.newPolicy = { policyNumber: '', type: 'Life', premium: 0 }; // Reset form
        this.loadMyPolicies(); // Refresh list
      },
      error: (err) => alert('Error creating policy.')
    });
  }
}