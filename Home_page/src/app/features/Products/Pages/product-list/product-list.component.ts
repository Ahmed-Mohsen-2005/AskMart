import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFilter } from '../../components/product-filter/product-filter.component';
import { ProductCard } from '../../components/product-card/product-card.component';

interface Product {
  id: number;
  name: string;
  price: number;
  category: string;
  image: string;
}

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [CommonModule, ProductFilter, ProductCard],
  templateUrl: './product-list.component.html'
})
export class ProductList {
  products: Product[] = [
    // Fruits
    { id: 1, name: 'Apple', price: 1.2, category: 'Fruits', image: 'https://via.placeholder.com/150?text=Apple' },
    { id: 2, name: 'Banana', price: 0.8, category: 'Fruits', image: 'https://via.placeholder.com/150?text=Banana' },
    { id: 3, name: 'Orange', price: 1.1, category: 'Fruits', image: 'https://via.placeholder.com/150?text=Orange' },
    { id: 4, name: 'Grapes', price: 2.5, category: 'Fruits', image: 'https://via.placeholder.com/150?text=Grapes' },

    // Vegetables
    { id: 5, name: 'Tomato', price: 1.5, category: 'Vegetables', image: 'https://via.placeholder.com/150?text=Tomato' },
    { id: 6, name: 'Potato', price: 0.6, category: 'Vegetables', image: 'https://via.placeholder.com/150?text=Potato' },
    { id: 7, name: 'Onion', price: 0.7, category: 'Vegetables', image: 'https://via.placeholder.com/150?text=Onion' },
    { id: 8, name: 'Carrot', price: 1.0, category: 'Vegetables', image: 'https://via.placeholder.com/150?text=Carrot' },

    // Bakery
    { id: 9, name: 'Bread', price: 1.8, category: 'Bakery', image: 'https://via.placeholder.com/150?text=Bread' },
    { id: 10, name: 'Croissant', price: 2.2, category: 'Bakery', image: 'https://via.placeholder.com/150?text=Croissant' },
    { id: 11, name: 'Cake', price: 5.0, category: 'Bakery', image: 'https://via.placeholder.com/150?text=Cake' },
    { id: 12, name: 'Muffin', price: 2.5, category: 'Bakery', image: 'https://via.placeholder.com/150?text=Muffin' },

    // Beverages
    { id: 13, name: 'Coffee', price: 3.0, category: 'Beverages', image: 'https://via.placeholder.com/150?text=Coffee' },
    { id: 14, name: 'Tea', price: 2.0, category: 'Beverages', image: 'https://via.placeholder.com/150?text=Tea' },
    { id: 15, name: 'Juice', price: 2.5, category: 'Beverages', image: 'https://via.placeholder.com/150?text=Juice' },
    { id: 16, name: 'Soda', price: 1.8, category: 'Beverages', image: 'https://via.placeholder.com/150?text=Soda' },

    // Grocery
    { id: 17, name: 'Rice', price: 4.0, category: 'Grocery', image: 'https://via.placeholder.com/150?text=Rice' },
    { id: 18, name: 'Pasta', price: 3.0, category: 'Grocery', image: 'https://via.placeholder.com/150?text=Pasta' },

    // Dairy
    { id: 19, name: 'Milk', price: 2.0, category: 'Dairy', image: 'https://via.placeholder.com/150?text=Milk' },
    { id: 20, name: 'Cheese', price: 3.5, category: 'Dairy', image: 'https://via.placeholder.com/150?text=Cheese' },
  ];

  filteredProducts = this.products;

  onFilterChanged(filter: { category: string, search: string }) {
    this.filteredProducts = this.products.filter(p =>
      (filter.category === 'All' || p.category === filter.category) &&
      p.name.toLowerCase().includes(filter.search.toLowerCase())
    );
  }
}
