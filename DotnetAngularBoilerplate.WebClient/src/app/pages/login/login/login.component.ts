import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginService } from '../login.service';
import { NgForm } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  isLoading = false;
  isRememberMeChecked = true;
  isRememberMeChecked2 = true;
  constructor(private loginService: LoginService, private primengConfig: PrimeNGConfig) {

  }
  ngOnInit(): void {
    //this.primengConfig.ripple = true;
    console.log(environment.isProd);

  }
  onLogin(loginForm: NgForm) {
    this.isLoading = !this.isLoading;
    console.log("onLogin")
    this.loginService.login(loginForm.value.email, loginForm.value.password).subscribe(result => {
      console.log(result)
    },
      error => (console.log(error)))

  }
  forgotPassword(){
    console.log("forgot password");
  }
}
