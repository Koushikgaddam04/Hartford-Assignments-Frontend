import { Component, OnInit, ChangeDetectorRef } from '@angular/core'; // Add ChangeDetectorRef
import { CommonModule } from '@angular/common';
import { Insurance } from '../../services/insurance';

@Component({
  selector: 'app-data-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './data-view.html',
})
export class DataView implements OnInit {
  policies: any[] = [];

  constructor(
    private insuranceService: Insurance,
    private cdr: ChangeDetectorRef // Inject it here
  ) {}

  ngOnInit(): void {
    this.fetchPolicies();
  }

  fetchPolicies() {
    this.insuranceService.getPolicies().subscribe({
      next: (data) => {
        this.policies = data;
        this.cdr.detectChanges(); // Force the UI to wake up
      },
      error: (err) => console.error('Connection error', err)
    });
  }
}