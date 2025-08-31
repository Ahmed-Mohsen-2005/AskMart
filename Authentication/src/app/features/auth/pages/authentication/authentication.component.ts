import { Component } from '@angular/core';
import {Logincomponent} from '../../components/login/login.component'
import {Signupcomponent} from '../../components/signup/signup.component'
import { Forgotpassword } from '../../components/forgotpassword/forgotpassword.component';
@Component({
  selector: 'app-authentication',
  imports: [Logincomponent ,Signupcomponent,Forgotpassword],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class Authentication {

}
