import {
  UserLoginDTO,
  RegisterUserDTO
} from './../../_services/swagger/SwaggerClient.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { SwaggerClient } from 'src/app/_services/swagger/SwaggerClient.service';
import { Encrypt } from 'src/app/Utility/app.Encryption';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit {
  email = '';
  password = '';
  fullname = '';
  username = '';
  signUpEmail = '';
  signUpPassword = '';
  signUpConfirmPassword = '';
  InvalidCredentials = false;
  constructor(private swagger: SwaggerClient) {}

  ngOnInit() {}

  ToggleSignUp() {
    const SignUpForm = document.getElementById('form-signup');
    const SignInForm = document.getElementById('form-signin');
    if (SignUpForm.style.display === 'none' || !SignUpForm.style.display) {
      SignUpForm.style.display = 'block';
      SignInForm.style.display = 'none';
    } else {
      SignUpForm.style.display = 'none';
      SignInForm.style.display = 'block';
    }
  }

  onLoginSubmit() {
    this.swagger
      .api_Account_Login({
        username: Encrypt(this.email),
        password: Encrypt(this.password)
      } as UserLoginDTO)
      .subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
        }
      );
  }

  onSignupSubmit() {
    this.swagger
      .api_Account_Register({
        fullName: this.fullname,
        confirmPassword: Encrypt(this.signUpConfirmPassword),
        password: Encrypt(this.signUpPassword),
        email: this.signUpEmail,
        username: this.username
      } as RegisterUserDTO)
      .subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
        }
      );
  }
}
