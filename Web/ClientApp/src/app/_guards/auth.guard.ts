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

  constructor(private router: Router, private auth: AuthService) {
    this.auth.currentUser.subscribe(user => {
      this.user = user;
      if (
        this.allowedRoleCode &&
        user &&
        user.userRoles
          .map(v => v.roleName.toUpperCase())
          .indexOf(this.allowedRoleCode.toUpperCase()) === -1
      ) {
        console.log('Permission Taken', this.allowedRoleCode);
        alert(`Permission Taken - ${this.allowedRoleCode}`);
        this.router.navigate(['/']);
      }
    });
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.user && this.auth.isAuthUserLoggedIn()) {
      console.log('LoggedIn');
      return true;
    } else {
      console.log('OnlyLoggedInUsers');
      // not logged in so redirect to login page with the return url and return false
      this.router.navigate(['/login'], {
        queryParams: { returnUrl: state.url !== '/' ? state.url : null }
      });
      return false;
    }
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const returnUrl = state.url;
    if (!this.auth.isAuthUserLoggedIn()) {
      this.router.navigate(['/login'], {
        queryParams: { returnUrl: returnUrl !== '/' ? returnUrl : null }
      });
      return false;
    }
    if (route.data.RoleCode) {
      const RoleCode = route.data.RoleCode.toString().toLocaleUpperCase();
      let allow = false;
      if (
        this.user &&
        this.user.userRoles.map(v => v.roleName).indexOf(RoleCode) > -1
      ) {
        console.log('Action Allowed', RoleCode);
        this.allowedRoleCode = RoleCode;
        this.firstURL = false;
        allow = true;
      } else {
        console.log('Action Not Allowed', RoleCode);
        alert(`Action Not Allowed - ${RoleCode}`);
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
