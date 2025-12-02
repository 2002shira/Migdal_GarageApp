import { Routes } from '@angular/router';
import { GarageComponent } from './garage/garage.component';

export const routes: Routes = [
  { path: '', component: GarageComponent },
  { path: '**', redirectTo: '' }
];
