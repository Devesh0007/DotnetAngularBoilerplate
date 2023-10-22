import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login/login.component';
import { InputModule,  } from '@ui';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { ButtonModule  } from 'primeng/button';
import { CheckboxModule  } from 'primeng/checkbox';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    InputModule,
    FormsModule,
    HttpClientModule,
    ButtonModule,
    CheckboxModule
  ],
  //providers: [LoginService]
})
export class LoginModule { }
