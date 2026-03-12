import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Insurance } from '../../services/insurance';

@Component({
  selector: 'app-agent-dash',
  standalone: true,
  imports: [], // CommonModule removed
  templateUrl: './agent-dash.html'
})
export class AgentDash implements OnInit {
  assignedPolicies: any[] = [];

  constructor(private insurance: Insurance, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.loadAssignedWork();
  }

  loadAssignedWork() {
    this.insurance.getPoliciesForAgent().subscribe({
      next: (res) => {
        console.log('Agent Workload:', res);
        this.assignedPolicies = res;
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Agent fetch error:', err)
    });
  }

  updateStatus(policyId: number, status: string) {
    this.insurance.updatePolicyStatus(policyId, status).subscribe({
      next: () => {
        alert(`Policy ${status} successfully.`);
        this.loadAssignedWork();
      }
    });
  }
}