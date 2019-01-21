import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminSiteRoutingModule } from './admin-site-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';

@NgModule({
  declarations: [ AdminHomeComponent ],
  imports: [
    CommonModule,
    AdminSiteRoutingModule,
  ]
})
export class AdminSiteModule { }
