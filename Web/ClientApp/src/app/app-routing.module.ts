import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {
    path: 'admin',
    loadChildren: './admin-site/admin-site.module#AdminSiteModule'
    // canActivate: [AuthGuard],
    // canActivateChild: [AuthGuard]
  },
  {
    path: 'client',
    loadChildren: './client-site/client-site.module#ClientSiteModule'
    // canActivate: [AuthGuard],
    // canActivateChild: [AuthGuard]
  },
  {
    path: 'login',
    loadChildren: './authentication/authentication.module#AuthenticationModule'
  },
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
