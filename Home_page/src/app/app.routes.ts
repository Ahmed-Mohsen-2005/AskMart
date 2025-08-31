import { Routes } from '@angular/router';
import { Home } from './features/Home_page/pages/home/home.component';
import { ProductList } from './features/Products/Pages/product-list/product-list.component';
import { Cart } from './features/cart/pages/cart/cart.component';
import { RouterOutlet } from '@angular/router';
export const routes: Routes = [
  { path: 'home', component: Home},
  { path: 'products', component: ProductList},
  { path: 'cart', component: Cart},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
];
