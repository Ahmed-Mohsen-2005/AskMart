import { Component } from '@angular/core';
import {Logincomponent} from '../../components/login/login.component'
import {Signupcomponent} from '../../components/signup/signup.component'
@Component({
  selector: 'app-authentication',
  imports: [Logincomponent ,Signupcomponent],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class Authentication {

}
