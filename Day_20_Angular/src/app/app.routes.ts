import { Routes } from '@angular/router';
import { LoginComponent } from '../components/login/login';
import { LayoutComponent } from '../components/layout/layout';
import { EmpComponent } from '../components/emp-component/emp-component';
import { ListEmpComponent } from '../components/list-emp-component/list-emp-component';
import { authGuard } from '../auth-guard';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: 'add-emp', component: EmpComponent },
      { path: 'list-emp', component: ListEmpComponent }
    ]
  }
];