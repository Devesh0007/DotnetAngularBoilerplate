import { Injectable } from '@angular/core';

import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

import { AuthService } from 'src/app/@shared/services/auth.service';

@Injectable({

  providedIn: 'root'

})

export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(

    next: ActivatedRouteSnapshot,

    state: RouterStateSnapshot){

      if (!this.authService.isLoggedIn()) {

        this.router.navigate(['/login']); // go to login if not authenticated

        return false;

      }

    return true;

  }

}