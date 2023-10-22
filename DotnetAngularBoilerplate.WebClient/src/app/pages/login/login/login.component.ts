import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginService } from '../login.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private _loginService: LoginService) {

  }
  ngOnInit(): void {
    console.log(environment.isProd);

  }
  onLogin(loginForm: NgForm) {
    console.log("onLogin")
    this._loginService.login(loginForm.value.email, loginForm.value.password).subscribe(result => {
      console.log(result)
    }, 
    error => (console.log(error)))
    
  }
}
