import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {Authentication} from './features/auth/pages/authentication/authentication.component'
@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class App {
  protected readonly title = signal('Authentication');
}
