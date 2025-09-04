import { Component } from '@angular/core';
import { Hero } from '../../components/hero/hero.component';
import { CategoryList } from '../../components/category-list/category-list.component';
import { ProductGrid } from '../../components/product-grid/product-grid.component';
import {SearchBar} from '../../components/search-bar/search-bar.component';
import {ChatbotButton} from '../../../../shared/components/chatbot-button/chatbot-button.component';
import { RouterOutlet } from '@angular/router';
import { Navbar } from '../../../../shared/components/navbar/navbar';
import { Footer } from '../../../../shared/components/footer/footer';
@Component({
  selector: 'app-home',
  imports: [Hero, CategoryList, ProductGrid, SearchBar, ChatbotButton, Navbar, Footer],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class Home {

}
