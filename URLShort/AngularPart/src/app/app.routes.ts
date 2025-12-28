import { Routes } from '@angular/router';
import { NotFoundComponent } from './not-found.component';
export const routes: Routes = [
  {
    path: 'table',
    loadChildren: './table/table.module#TableModule',
  },
  { path: '**', pathMatch: 'full', component: NotFoundComponent }
];
