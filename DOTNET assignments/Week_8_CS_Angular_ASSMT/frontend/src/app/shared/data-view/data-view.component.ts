import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsuranceService } from '../../core/services/insurance.service';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-data-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './data-view.component.html'
})
export class DataViewComponent implements OnInit {
  policies: any[] = [];
  role: string | null = '';
  userId: number | null = null;
  loading = true;

  constructor(
    private insuranceService: InsuranceService,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.authService.currentUser$.subscribe(user => {
      if (user) {
        this.role = user.role;
        this.userId = user.userId;
        this.fetchPolicies();
      }
    });
  }

  fetchPolicies() {
    this.loading = true;
    if (this.role === 'Admin') {
      this.insuranceService.getAllPolicies().subscribe(res => this.handleSuccess(res));
    } else if (this.role === 'Agent') {
      // For simplicity, agentId is mapped 1:1 with userId or we fetch assigning agent.
      // E.g., user.userId is the AgentId in our simplified structure
      this.insuranceService.getPoliciesByAgent(this.userId!).subscribe(res => this.handleSuccess(res));
    } else if (this.role === 'Customer') {
      this.insuranceService.getCustomerProfile(this.userId!).subscribe({
        next: (profile) => {
          this.insuranceService.getPoliciesByCustomer(profile.id).subscribe(res => this.handleSuccess(res));
        },
        error: () => this.handleSuccess([])
      });
    }
  }

  handleSuccess(res: any[]) {
    this.policies = res;
    this.loading = false;
  }

  acceptPolicy(policyId: number) {
    this.insuranceService.updatePolicyStatus(policyId, 'Accepted').subscribe(() => this.fetchPolicies());
  }

  rejectPolicy(policyId: number) {
    this.insuranceService.updatePolicyStatus(policyId, 'Rejected').subscribe(() => this.fetchPolicies());
  }
}
