import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataViewComponent } from '../../shared/data-view/data-view.component';
import { CreateRecordComponent } from '../../shared/create-record/create-record.component';
import { RouterLink } from '@angular/router';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-customer-dashboard',
  standalone: true,
  imports: [CommonModule, DataViewComponent, CreateRecordComponent, RouterLink],
  templateUrl: './customer-dashboard.component.html'
})
export class CustomerDashboardComponent {
  @ViewChild('dataView') dataView!: DataViewComponent;

  onRecordCreated() {
    if (this.dataView) {
      this.dataView.fetchPolicies();
    }
  }
}
