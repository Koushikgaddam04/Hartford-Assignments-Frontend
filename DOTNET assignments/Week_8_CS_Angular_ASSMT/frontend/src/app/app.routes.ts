import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { LoginComponent } from './features/auth/login/login.component';
import { RegisterComponent } from './features/auth/register/register.component';
import { AdminDashboardComponent } from './features/admin-dashboard/admin-dashboard.component';
import { AgentDashboardComponent } from './features/agent-dashboard/agent-dashboard.component';
import { CustomerDashboardComponent } from './features/customer-dashboard/customer-dashboard.component';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'admin', component: AdminDashboardComponent, canActivate: [authGuard], data: { roles: ['Admin'] } },
    { path: 'agent', component: AgentDashboardComponent, canActivate: [authGuard], data: { roles: ['Admin', 'Agent'] } },
    { path: 'customer', component: CustomerDashboardComponent, canActivate: [authGuard], data: { roles: ['Admin', 'Customer'] } },
    { path: '**', redirectTo: '' }
];
