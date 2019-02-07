import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { CategoryComponent } from './category/category.component';

const routes: Routes = [
  {
    path: '',
    component: AdminHomeComponent
  },
  {
    path: 'category',
    component: CategoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminSiteRoutingModule {}
