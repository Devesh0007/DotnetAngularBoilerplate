import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthRoutingModule } from './auth-routing.module';
import { InputModule,  } from '@ui';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { ButtonModule  } from 'primeng/button';
import { CheckboxModule  } from 'primeng/checkbox';
import { LoginComponent } from './login/login.component';
import { SsoLoginComponent } from './sso-login/sso-login.component';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    SsoLoginComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    InputModule,
    FormsModule,
    HttpClientModule,
    ButtonModule,
    CheckboxModule
  ],
})
export class AuthModule { }
