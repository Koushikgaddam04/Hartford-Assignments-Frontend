import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Insurance } from '../../services/insurance';

@Component({
  selector: 'app-admin-dash',
  standalone: true,
  imports: [], // CommonModule removed
  templateUrl: './admin-dash.html'
})
export class AdminDash implements OnInit {
  pendingCustomers: any[] = [];
  agents: any[] = [];
  allPolicies: any[] = [];
  currentTab: string = 'assignments';

  constructor(private insurance: Insurance, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    // Fetch Customers without agents
    this.insurance.getPendingCustomers().subscribe({
      next: (data) => {
        console.log('Pending Customers:', data);
        this.pendingCustomers = data;
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Error fetching customers:', err)
    });

    // Fetch Agents for the dropdown
    this.insurance.getAgents().subscribe({
      next: (data) => {
        console.log('Agents available:', data);
        this.agents = data;
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Error fetching agents:', err)
    });

    // Fetch All Policies for the second tab
    this.insurance.getAllPolicies().subscribe({
      next: (data) => {
        console.log('All System Policies:', data);
        this.allPolicies = data;
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Error fetching all policies:', err)
    });
  }

  onAssign(customerId: number, agentId: string) {
    if (!agentId) {
      alert("Please select an agent first.");
      return;
    }
    
    this.insurance.assignAgent(customerId, parseInt(agentId)).subscribe({
      next: () => {
        alert('Agent assigned successfully!');
        this.loadData(); // Refresh both lists
      },
      error: (err) => alert("Assignment failed. Check console.")
    });
  }
}