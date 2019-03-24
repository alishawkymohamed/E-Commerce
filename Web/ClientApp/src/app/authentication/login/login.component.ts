import { Router, ActivatedRoute } from '@angular/router';
import {
  UserLoginDTO,
  RegisterUserDTO
} from './../../_services/swagger/SwaggerClient.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { SwaggerClient } from 'src/app/_services/swagger/SwaggerClient.service';
import { Encrypt } from 'src/app/Utility/app.Encryption';
import { AuthService } from 'src/app/_services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';

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
  role = '2';

  returnUrl: string;
  request = false;
  dataError = false;
  error = 'An error occurred';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private swagger: SwaggerClient,
    private auth: AuthService
  ) {}

  ngOnInit() {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.auth.currentUser.subscribe(user => {
      if (user) {
        this.router.navigate(['']);
      }
    });
  }

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
    if (!this.request) {
    }
    this.auth
      .login({
        username: Encrypt(this.email),
        password: Encrypt(this.password)
      } as UserLoginDTO)
      .subscribe(
        isLoggedIn => {
          if (isLoggedIn) {
            this.getAuthticket();
          }
        },
        (error: HttpErrorResponse) => {
          this.request = false;
          this.dataError = true;
          if (error.status === 401) {
            this.error = 'Invalid User name or Password. Please try again.';
          } else {
            this.error = `${error.statusText}: ${error.message}`;
          }
          console.log(this.error);
        },
        () => {
          this.request = false;
        }
      );
  }

  onSignupSubmit(signupForm) {
    this.swagger
      .api_Account_Register({
        fullName: this.fullname,
        confirmPassword: Encrypt(this.signUpConfirmPassword),
        password: Encrypt(this.signUpPassword),
        email: this.signUpEmail,
        username: this.username,
        // tslint:disable-next-line: radix
        roleId: parseInt(this.role)
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

  getAuthticket() {
    this.swagger.api_Account_GetUserAuthTicket().subscribe(
      data => {
        this.auth.setUser(data);
        this.router.navigate([this.returnUrl]);
      },
      error => {
        console.log(error);
      }
    );
  }
}
