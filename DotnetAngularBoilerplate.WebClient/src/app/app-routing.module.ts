import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StaticComponent } from './@core/components/static/static.component';
import { AuthGuard } from './@core/gaurds/auth.guard';

const routes: Routes = [
  {
    path: '', 
    component: StaticComponent,
    canActivate: [AuthGuard],
    loadChildren: ()=> import('./pages/pages.module').then(x=> x.PagesModule)  
  },
  {
    path: 'login', 
    loadChildren: ()=> import('./pages/login/login.module').then(x=> x.LoginModule)  
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
