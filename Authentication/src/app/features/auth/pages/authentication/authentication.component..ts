import { Component } from '@angular/core';
import {Login} from '../../components/login/login.component'
import {Register} from '../../components/register/register.component'
@Component({
  selector: 'app-authentication',
  imports: [Login,Register],
  templateUrl: './authentication.component..html',
  styleUrl: './authentication.component.css'
})
export class Authentication {

}
