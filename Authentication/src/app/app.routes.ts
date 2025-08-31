
import { Routes } from '@angular/router';
import { Logincomponent } from './features/auth/components/login/login.component';
import { Signupcomponent } from './features/auth/components/signup/signup.component';
import { Forgotpassword } from './features/auth/components/forgotpassword/forgotpassword.component';
export const routes: Routes = [
    { 
        path: 'login',  
        component:Logincomponent,
    },
    { 
        path: 'signup', 
        component:Signupcomponent 
    },
    // { path: 'login', loadComponent: ()=>import('./features/auth/components/login/login.component').then(m=>m.Logincomponent)},
    // { path: 'signup', loadComponent: ()=>import('./features/auth/components/signup/signup.component').then(m=>m.Signupcomponent)},
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
