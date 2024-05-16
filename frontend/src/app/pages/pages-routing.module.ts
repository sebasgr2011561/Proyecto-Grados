import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// component
import { IndexComponent } from './index/index.component';
import { CategoryComponent } from './category/category.component';
import { RestaurantsComponent } from './restaurants/restaurants.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { AuctionLiveComponent } from './auction-live/auction-live.component';




const routes: Routes = [
  {
    path: '',
    component: IndexComponent
  },
  {
    path: 'category/:id',
    component: CategoryComponent
  },
  {
    path: 'restaurants',
    component: RestaurantsComponent
  },
  {
    path: 'cart',
    component: CartComponent
  },
  {
    path: 'checkout',
    component: CheckoutComponent
  },
  {
    path: 'restaurants', component: RestaurantsComponent
  },
  {
    path: 'recurso', component: AuctionLiveComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
