import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientHomeComponent } from './client-home/client-home.component';

const routes: Routes = [
  {
    path: '',
    component: ClientHomeComponent
  }
];

@NgModule({
  imports: [ RouterModule.forChild(routes) ],
  exports: [ RouterModule ]
})
export class ClientSiteRoutingModule { }
