import { Inject, Injectable } from '@angular/core';
import { User } from '../data-structures/models/User';
import { UsersService } from '../data-access/users.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private isLoggedInSource = new BehaviorSubject<boolean>(!!this.currentUser);
  private _isLoggedIn: Observable<boolean> = this.isLoggedInSource.asObservable();

  redirectUrl: string;

  constructor(private userService: UsersService) {
  }

  get isLoggedIn() {
    return !!this.currentUser;
  }

  set isLoggedIn(value: any) {
    this.isLoggedInSource.next(value);
  }

  get currentUser() {
    const userJson = localStorage.getItem('currentUser');
    if (userJson) {
      const castUser = JSON.parse(userJson);
      let user = Object.assign(new User(), castUser );
      return user;
    }
    return null;
  }

  public login(userName: string, password: string): boolean {

    let user = this.userService.getUser(userName, password);

    if (user != null) {
      localStorage.removeItem('currentUser');
      localStorage.setItem('currentUser', JSON.stringify(user));
      this.isLoggedIn = true;
      return true;
    }
    else {
      localStorage.removeItem('currentUser');
      this.isLoggedIn = true;
      return false
    }
  }

  public logout(): void {
    localStorage.removeItem('currentUser');
  }

}
