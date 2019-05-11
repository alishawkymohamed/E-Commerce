import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { CategoryComponent } from './category/category.component';
import { SubCategoryComponent } from './sub-category/sub-category.component';
import { CategoryLookupResolver } from './_services/category-services/category-lookup.resolver';
import { ProductComponent } from './product/product.component';
import { AddEditProductComponent } from './product/add-edit-product/add-edit-product.component';
import { SubCategoryLookupResolver } from './_services/sub-category-services/subCategory-lookup.resolver';

const routes: Routes = [
  {
    path: '',
    component: AdminHomeComponent,
    data: { RoleCode: 'Admin' }
  },
  {
    path: 'category',
    component: CategoryComponent,
    data: { RoleCode: 'Admin' }
  },
  {
    path: 'sub-category',
    component: SubCategoryComponent,
    data: { RoleCode: 'Admin' },
    resolve: {
      CategoryLookup: CategoryLookupResolver
    }
  },
  {
    path: 'product',
    component: ProductComponent,
    data: { RoleCode: 'Admin' }
  },
  {
    path: 'product/add',
    component: AddEditProductComponent,
    data: { RoleCode: 'Admin' },
    resolve: {
      CategoryLookup: CategoryLookupResolver,
      SubCategoryLookup: SubCategoryLookupResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [CategoryLookupResolver, SubCategoryLookupResolver]
})
export class AdminSiteRoutingModule { }
