import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminSiteRoutingModule } from './admin-site-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { CategoryComponent } from './category/category.component';
import { SharedModule } from '../shared.module';
import { AddEditCategoryComponent } from './category/add-edit-category/add-edit-category.component';
import { DialogService } from 'primeng/api';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SubCategoryComponent } from './sub-category/sub-category.component';
import { AddEditSubCategoryComponent } from './sub-category/add-edit-sub-category/add-edit-sub-category.component';

@NgModule({
  declarations: [
    AdminHomeComponent,
    CategoryComponent,
    AddEditCategoryComponent,
    SubCategoryComponent,
    AddEditSubCategoryComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    AdminSiteRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  entryComponents: [AddEditCategoryComponent, AddEditSubCategoryComponent],
  providers: [DialogService]
})
export class AdminSiteModule {}
