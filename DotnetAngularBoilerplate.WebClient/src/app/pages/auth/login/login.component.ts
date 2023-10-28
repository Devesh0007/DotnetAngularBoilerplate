import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
import { ILoginDetails } from 'src/app/@core/interfaces/login.interface';
import { SessionStorageEnum } from 'src/app/@core/enums/session-storage';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/@shared/services/shared.service';
import { AuthService } from '@pages';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  isLoading = false;
  isRememberMeChecked = true;
  constructor(private sharedService: SharedService, private authService: AuthService, private primengConfig: PrimeNGConfig, private router: Router, private route: ActivatedRoute) {
    this.sharedService.isNavbarActive = false;
  }
  ngOnInit(): void {
    this.primengConfig.ripple = true;
    // const isLoggedIn = this.authService.isLoggedIn();
    // if(isLoggedIn){
    //   this.router.navigate(['/']);
    // }
    this.sharedService.headerUserName = sessionStorage.getItem(SessionStorageEnum.FirstName)?.charAt(0) ?? '' + sessionStorage.getItem(SessionStorageEnum.LastName)?.charAt(0) ?? '';
  }
  onLogin(loginForm: NgForm) {
    const loginDetails = {
      email: loginForm.value.loginEmailUsername,
      username: loginForm.value.loginEmailUsername,
      password: loginForm.value.loginPassword,
      rememberMe: loginForm.value.loginRememberMe
    } as ILoginDetails;

    this.isLoading = true;

    console.log(loginDetails)
    this.authService.login(loginDetails).subscribe(
      result => {
        sessionStorage.setItem(SessionStorageEnum.AccessToken, result.token);
        sessionStorage.setItem(SessionStorageEnum.UserId, result.userId);
        sessionStorage.setItem(SessionStorageEnum.FirstName, result.firstName);
        sessionStorage.setItem(SessionStorageEnum.LastName, result.lastName);
        sessionStorage.setItem(SessionStorageEnum.ExpiresOn, Date.parse(result.expiresOn).toString());
        this.sharedService.headerUserName = result.firstName.charAt(0) + result.lastName.charAt(0);
        this.isLoading = false;
        this.sharedService.isNavbarActive = true;
        this.router.navigate(['']);
      },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );

  }
  forgotPassword() {
    console.log('forgot password');
  }
  onSocialLogin(provider: string) {
    console.log(provider);

  }
  redirectToRegister() {
    console.log('redirectToRegister');
  }
}
