import { Injectable } from '@angular/core';

import { CanActivate, CanActivateChild, Router } from '@angular/router';
import { AuthTicketDTO } from '../_services/swagger/SwaggerClient.service';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {
  user: AuthTicketDTO;
  allowedRoleCode: string;
  firstURL = true;

  constructor(
    private authService: AuthService,
    private router: Router,
    private auth: AuthService
  ) {
    this.auth.currentUser.subscribe(user => {
      this.user = user;
      if (
        this.allowedRoleCode &&
        user &&
        user.userRoles.map(v => v.roleName).indexOf(this.allowedRoleCode) === -1
      ) {
        console.log('Permission Taken', this.allowedRoleCode);
        alert(`Permission Taken - ${this.allowedRoleCode}`);
        this.router.navigate(['/']);
      }
    });
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.user && this.authService.isAuthUserLoggedIn()) {
      console.log('LoggedIn');
      return true;
    } else {
      console.log('OnlyLoggedInUsers');
      // not logged in so redirect to login page with the return url and return false
      this.router.navigate(['/login'], {
        queryParams: { returnUrl: state.url }
      });
      return false;
    }
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const returnUrl = state.url;
    if (!this.authService.isAuthUserLoggedIn()) {
      this.router.navigate(['/login'], {
        queryParams: { returnUrl: returnUrl }
      });
      return false;
    }
    if (route.data.permissionCode) {
      const permissionCode = route.data.permissionCode
        .toString()
        .toLocaleUpperCase();
      let allow = false;
      if (
        this.user &&
        this.user.userRoles.map(v => v.roleName).indexOf(permissionCode) > -1
      ) {
        console.log('Action Allowed', permissionCode);
        this.allowedRoleCode = permissionCode;
        this.firstURL = false;
        allow = true;
      } else {
        console.log('Action Not Allowed', permissionCode);
        alert(`Action Not Allowed - ${permissionCode}`);
        // TODO: navigation history
        if (this.firstURL) {
          this.router.navigate(['/']);
        }
      }
      return allow;
    } else {
      this.allowedRoleCode = null;
      return true;
    }
  }
}
