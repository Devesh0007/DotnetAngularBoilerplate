import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard, NotFoundComponent, StaticComponent } from './@core';

const routes: Routes = [
  {
    path: '',
    component: StaticComponent,
    canActivate: [AuthGuard],
    loadChildren: () => import('./pages/pages.module').then(x => x.PagesModule)
  },
  {
    path: 'auth',
    loadChildren: () => import('./pages/auth/auth.module').then(x => x.AuthModule)
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
