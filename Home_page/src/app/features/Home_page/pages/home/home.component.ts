import { Component } from '@angular/core';
import { Hero } from '../../components/hero/hero.component';
import { CategoryList } from '../../components/category-list/category-list.component';
import { ProductGrid } from '../../components/product-grid/product-grid.component';
import {SearchBar} from '../../components/search-bar/search-bar.component';
import {ChatbotButton} from '../../../../shared/components/chatbot-button/chatbot-button.component';

@Component({
  selector: 'app-home',
  imports: [Hero, CategoryList, ProductGrid, SearchBar, ChatbotButton],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class Home {

}
