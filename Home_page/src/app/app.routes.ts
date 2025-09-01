import { Routes } from '@angular/router';
import { Home } from './features/Home_page/pages/home/home.component';
import { ProductList } from './features/Products/Pages/product-list/product-list.component';
import { Cart } from './features/cart/pages/cart/cart.component';
import { Logincomponent } from './features/auth/components/login/login.component';
import { Signupcomponent } from './features/auth/components/signup/signup.component';
import { Forgotpassword } from './features/auth/components/forgotpassword/forgotpassword.component';
export const routes: Routes = [
  { path: 'home', component: Home},
  { path: 'products', component: ProductList},
  { path: 'cart', component: Cart},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  { 
        path: 'login',  
        component:Logincomponent,
    },
    { 
        path: 'signup', 
        component:Signupcomponent 
    },
    {
        path: '' , 
        redirectTo: 'login',
        pathMatch: "full"
    },
    { 
        path: 'forgotpassword',  
        component:Forgotpassword
    }
];
