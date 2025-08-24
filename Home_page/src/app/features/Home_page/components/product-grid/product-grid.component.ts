import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
@Component({
  selector: 'app-product-grid',
  imports: [NgFor],
  templateUrl: './product-grid.component.html',
  styleUrl: './product-grid.component.css'
})
export class ProductGrid {
products = [
    { id: 1, name: 'Apple', price: 2.99, image: 'apple.jpeg' },
    { id: 2, name: 'Bread', price: 1.49, image: 'bread.jpg' },
    { id: 3, name: 'Milk', price: 0.99, image: 'milk.jpg' },
  ];
}
