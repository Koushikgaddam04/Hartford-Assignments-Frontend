import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InsuranceService } from '../../core/services/insurance.service';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-create-record',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-record.component.html'
})
export class CreateRecordComponent implements OnInit {
  @Output() recordCreated = new EventEmitter<void>();

  policyData = {
    policyNumber: '',
    policyType: 'Auto',
    premiumAmount: 0,
    customerId: 0
  };

  message = '';
  isError = false;

  hasProfile = false;

  constructor(
    private insuranceService: InsuranceService,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.authService.currentUser$.subscribe(user => {
      if (user && user.role === 'Customer') {
        this.insuranceService.getCustomerProfile(user.userId).subscribe({
          next: (profile) => {
            this.policyData.customerId = profile.id;
            this.hasProfile = true;

            // Check if Admin assigned an agent
            if (!profile.agentId) {
              this.message = 'You must wait for an Admin to assign an Agent to your profile before applying for policies.';
              this.isError = true;
              this.hasProfile = false; // block the form
            }
          },
          error: () => {
            this.message = 'Please wait while your profile is being set up. (Contact Admin)';
            this.isError = true;
            this.hasProfile = false;
          }
        });
      }
    });
  }

  onSubmit() {
    if (!this.hasProfile) return;

    this.insuranceService.createPolicy(this.policyData).subscribe({
      next: (res) => {
        this.message = 'Policy application submitted successfully!';
        this.isError = false;
        this.policyData.policyNumber = '';
        this.policyData.premiumAmount = 0;
        this.recordCreated.emit();
      },
      error: (err) => {
        this.message = 'Failed to submit policy.';
        this.isError = true;
      }
    });
  }
}
