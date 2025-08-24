import { Routes } from '@angular/router';
import { Home } from './features/Home_page/pages/home/home.component';
import { ProductList } from './features/Products/Pages/product-list/product-list.component';
import { Cart } from './features/cart/pages/cart/cart.component';
export const routes: Routes = [
  { path: '', component: Home},
  { path: 'products', component: ProductList},
  { path: 'cart', component: Cart},
];
