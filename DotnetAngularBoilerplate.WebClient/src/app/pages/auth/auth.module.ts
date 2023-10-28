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

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
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
  //providers: [LoginService]
})
export class AuthModule { }
