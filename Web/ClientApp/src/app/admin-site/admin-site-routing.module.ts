import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { CategoryComponent } from './category/category.component';
import { SubCategoryComponent } from './sub-category/sub-category.component';
import { CategoryLookupResolver } from './_services/sub-category-services/categor-lookup.resolver';

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
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [CategoryLookupResolver]
})
export class AdminSiteRoutingModule {}
