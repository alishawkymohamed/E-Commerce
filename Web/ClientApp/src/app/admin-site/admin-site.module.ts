import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminSiteRoutingModule } from './admin-site-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { CategoryComponent } from './category/category.component';

@NgModule({
  declarations: [ AdminHomeComponent, CategoryComponent ],
  imports: [
    CommonModule,
    AdminSiteRoutingModule,
  ]
})
export class AdminSiteModule { }
