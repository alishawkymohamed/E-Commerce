import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminSiteRoutingModule } from './admin-site-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { CategoryComponent } from './category/category.component';
import { SharedModule } from '../shared.module';
import { AddEditCategoryComponent } from './category/add-edit-category/add-edit-category.component';
import { DialogService } from 'primeng/api';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AdminHomeComponent,
    CategoryComponent,
    AddEditCategoryComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    AdminSiteRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  entryComponents: [AddEditCategoryComponent],
  providers: [DialogService]
})
export class AdminSiteModule {}
