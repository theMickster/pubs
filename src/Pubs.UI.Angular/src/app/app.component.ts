
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { environment } from '../environments/environment';
import { AuthenticationService } from './auth/authentication.service';
import { User } from './data-structures/models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public ENVIRONMENT = environment;
  public title = 'pubs';
  public currentUser: User = null;
  private authServiceSub!: Subscription;

  get isLoggedIn() {
    return this.authService.isLoggedIn;
  }

  get displayUserFullName() : string {
    if(this.isLoggedIn){
      return this.authService.currentUser.fullName;
    }
    else {
      return "Unknown Username";
    }
  }

  constructor(private authService: AuthenticationService) {
  }

  ngOnInit() {
    // this.authServiceSub = this.authService.isLoggedIn.subscribe((isLoggedIn) => {
    //   if (isLoggedIn) {
    //     this.getUserInformation();
    //   }
    // });
  }

  public logout = () => {
    this.authService.logout();
  };

  private getUserInformation = () => {
    this.currentUser = this.authService.currentUser;
  }
}
