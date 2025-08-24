import { Routes } from '@angular/router';
import {Login} from './features/auth/components/login/login.component'
import {Register} from './features/auth/components/register/register.component'
export const routes: Routes = [
    { path: 'login', component: Login },
    { path: 'register', component: Register },
];
