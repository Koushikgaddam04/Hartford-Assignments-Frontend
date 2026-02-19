import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { DataView } from './components/data-view/data-view';
import { CreateRecord } from './components/create-record/create-record';

export const routes: Routes = [
  { path: 'home', component: Home },
  { path: 'data', component: DataView },
  { path: 'create', component: CreateRecord },
  { path: '', redirectTo: '/home', pathMatch: 'full' } // Default to home
];