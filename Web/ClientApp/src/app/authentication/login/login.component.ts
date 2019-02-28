import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit {
  constructor() {}

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
}
