import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientSiteRoutingModule } from './client-site-routing.module';
import { ClientHomeComponent } from './client-home/client-home.component';

@NgModule({
  declarations: [ClientHomeComponent],
  imports: [
    CommonModule,
    ClientSiteRoutingModule
  ]
})
export class ClientSiteModule { }
