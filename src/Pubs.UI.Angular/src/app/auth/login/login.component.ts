import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  errorMessage: string;
  pageTitle = 'Log In';

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {

  }

  login(loginForm: NgForm): void {
    if (loginForm && loginForm.valid) {
      this.errorMessage = '';
      const userName = loginForm.form.value.userName;
      const password = loginForm.form.value.password;
      let loginSuccess = this.authService.login(userName, password);

      if (loginSuccess) {
        console.log(`The user ${this.authService.currentUser.username} is now logged into pubs.`);
        this.router.navigate(['/']);
      }
    } 
    
    this.errorMessage = 'Please enter a valid user name and password.';    
  }
}
