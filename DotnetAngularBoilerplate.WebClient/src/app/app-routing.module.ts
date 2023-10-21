import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { 
    path: '', 
    loadChildren: ()=> import('./pages/login/login.module').then(x=> x.LoginModule)  
  },
  {
    path: 'login', 
    loadChildren: ()=> import('./pages/login/login.module').then(x=> x.LoginModule)  
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
