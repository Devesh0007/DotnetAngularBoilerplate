import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent, UserManagementComponent } from '@pages';
import { AuthGuard, StaticComponent } from '../@core';

const routes: Routes = [
  {
    path: '', component: StaticComponent, canActivate: [AuthGuard],
    children: [
      { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
      { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
      { path: 'user-management', component: UserManagementComponent, canActivate: [AuthGuard] },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
