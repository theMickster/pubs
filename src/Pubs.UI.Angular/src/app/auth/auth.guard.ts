import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Observable, of } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {

  
  constructor(
    private authService: AuthenticationService,
    private router: Router) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return of(this.checkedLoggedIn( state.url ));
  }

  canActivateChild(
    childRoute: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return of( this.checkedLoggedIn( state.url ));
  }


  canLoad(route: Route): Observable<boolean> {
    return of(this.checkedLoggedIn(route.path));
  }

  checkedLoggedIn(fromUrl: string) : boolean {
    if( this.authService.isLoggedIn ){
      this.authService.redirectUrl = null;
      return true;
    }
    this.authService.redirectUrl = fromUrl;
    this.router.navigate(['/welcome']);
    return false;
  }
}
