import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { routes } from './app.routes';
import {Home} from './features/Home_page/pages/home/home.component';
import { Navbar } from './shared/components/navbar/navbar';
import { Footer } from './shared/components/footer/footer';
@Component({
  selector: 'app-root',
  imports: [Home, Navbar, Footer],
  templateUrl: './app.html',
  styleUrl: './app.css'
}) 
export class App {
  protected readonly title = signal('Home_page');
}
