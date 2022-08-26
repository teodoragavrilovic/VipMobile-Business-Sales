import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/auth/auth.guard';
import { HomeComponent } from './home/home.component';
import { TariffPackageComponent } from './tariff-package/tariff-package.component';
import { ThOfferComponent } from './th-offer/th-offer.component';

const routes: Routes = [
  // {
  //   path: 'auth',
  //   component: AuthComponent
  // },
  {
    path: 'tariff-package',
    component: TariffPackageComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'th-offer',
    component: ThOfferComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: '**',
    redirectTo: '/home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
