import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DataViewComponent } from '../../shared/data-view/data-view.component';
import { RouterLink } from '@angular/router';
import { InsuranceService } from '../../core/services/insurance.service';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, DataViewComponent, RouterLink],
  templateUrl: './admin-dashboard.component.html'
})
export class AdminDashboardComponent implements OnInit {
  customers: any[] = [];

  // To keep things simple without creating a full user management API: 
  // We'll hardcode one agent ID for the dropdown or just accept an input.
  // In a real app we would have a GET /Agents endpoint.
  agentIdToAssign: number | null = null;
  message: string = '';

  constructor(private insuranceService: InsuranceService) { }

  ngOnInit() {
    this.fetchCustomers();
  }

  fetchCustomers() {
    this.insuranceService.getAllCustomers().subscribe(res => {
      this.customers = res;
    });
  }

  assignAgent(customerId: number, agentIdStr: string) {
    const agentId = parseInt(agentIdStr);
    if (!agentId || isNaN(agentId)) {
      this.message = 'Please enter a valid Agent ID to assign.';
      return;
    }

    this.insuranceService.assignAgentToCustomer(customerId, agentId).subscribe({
      next: () => {
        this.message = `Successfully assigned Agent ${agentId} to Customer ${customerId}`;
        this.fetchCustomers(); // refresh the list
      },
      error: () => {
        this.message = 'Failed to assign agent. (Are you sure that Agent ID exists?)';
      }
    });
  }
}
