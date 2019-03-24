import { Injectable, NgZone } from '@angular/core';
import { SwaggerClient } from './swagger/SwaggerClient.service';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class TrackRoleChangeService {
  constructor(
    private ngZone: NgZone,
    private swagger: SwaggerClient,
    private auth: AuthService
  ) {
    // this.signalR.onConnected.subscribe(x => {
    //   this.registerTrackToSignalR();
    // });
  }

  // registerTrackToSignalR() {
  //   this.signalR.on('UserRoleUpdated', data => {
  //     this.ngZone.run(() => {
  //       this.updateUserRolesCache();
  //     });
  //   });
  // }

  updateUserRolesCache() {
    console.log('User Roles Changed');
    this.swagger.api_Account_GetUserAuthTicket().subscribe(data => {
      console.log(data);
      this.auth.setUser(data);
    });
  }
}
