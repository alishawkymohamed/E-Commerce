import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminSiteRoutingModule } from './admin-site-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { CategoryComponent } from './category/category.component';
import { SharedModule } from '../shared.module';

@NgModule({
  declarations: [ AdminHomeComponent, CategoryComponent ],
  imports: [
    CommonModule,
    AdminSiteRoutingModule,
    SharedModule
  ]
})
export class AdminSiteModule { }
