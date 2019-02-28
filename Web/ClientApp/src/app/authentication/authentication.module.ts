import { AuthenticationRoutingModule } from './authentication-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared.module';

@NgModule({
  declarations: [LoginComponent],
  imports: [SharedModule, CommonModule, AuthenticationRoutingModule]
})
export class AuthenticationModule {}
