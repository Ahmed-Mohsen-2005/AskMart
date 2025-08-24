import { Component } from '@angular/core';
import { Hero } from '../../components/hero/hero.component';
import { CategoryList } from '../../components/category-list/category-list.component';
import { ProductGrid } from '../../components/product-grid/product-grid.component';
import {SearchBar} from '../../components/search-bar/search-bar.component';
@Component({
  selector: 'app-home',
  imports: [Hero, CategoryList, ProductGrid, SearchBar],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class Home {

}
