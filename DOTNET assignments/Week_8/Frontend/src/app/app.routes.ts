import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { AdminDash } from './components/admin-dash/admin-dash';
import { AgentDash } from './components/agent-dash/agent-dash';
import { CustomerDash } from './components/customer-dash/customer-dash';

export const routes: Routes = [
  // Default route redirects to Login
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  
  // Auth Routes
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  
  // Role-Based Dashboards
  { path: 'admin-dashboard', component: AdminDash },
  { path: 'agent-dashboard', component: AgentDash },
  { path: 'customer-dashboard', component: CustomerDash },

  // Wildcard route (Optional: redirect to login for any unknown path)
  { path: '**', redirectTo: 'login' }
];