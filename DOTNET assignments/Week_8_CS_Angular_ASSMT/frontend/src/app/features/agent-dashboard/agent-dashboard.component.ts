import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataViewComponent } from '../../shared/data-view/data-view.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-agent-dashboard',
  standalone: true,
  imports: [CommonModule, DataViewComponent, RouterLink],
  templateUrl: './agent-dashboard.component.html'
})
export class AgentDashboardComponent { }
