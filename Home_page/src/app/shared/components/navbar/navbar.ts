import { Component } from '@angular/core';

@Component({
  selector: 'app-navbar',
  imports: [],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css'
})
export class Navbar {

  toggleDarkMode() {
    document.body.classList.toggle('dark-theme');
  }
}
