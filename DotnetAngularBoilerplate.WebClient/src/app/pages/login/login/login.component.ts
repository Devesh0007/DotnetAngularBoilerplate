import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginService } from '../login.service';
import { NgForm } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
import { ILoginDetails } from 'src/app/@core/interfaces/login.interface';
import { SessionStorageEnum } from 'src/app/@core/enums/session-storage';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/@shared/services/shared.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  isLoading = false;
  isRememberMeChecked = true;
  isRememberMeChecked2 = true;
  constructor(private loginService: LoginService, private sharedService: SharedService, private primengConfig: PrimeNGConfig, private router: Router) {
    this.sharedService.isNavbarActive = false;
  }
  ngOnInit(): void {
    this.primengConfig.ripple = true;
    ///console.log(environment.isProd);
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
    this.loginService.login(loginDetails).subscribe(
      result => {
        sessionStorage.setItem(SessionStorageEnum.AccessToken, result.token);
        sessionStorage.setItem(SessionStorageEnum.UserId, result.userId);
        this.isLoading = false;
        this.sharedService.isNavbarActive = true;
        this.router.navigate(['/dashboard']);
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
