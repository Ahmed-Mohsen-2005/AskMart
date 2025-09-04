import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
@Component({
  selector: 'app-category-list',
  imports: [NgFor],
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryList {
categories = [
    { id: 1, name: 'Fruits', image: 'fruits.jpeg' },
    { id: 2, name: 'Vegetables', image: 'vegetables.jpg' },
    { id: 3, name: 'Bakery', image: 'bakery.jpg' },
    { id: 4, name: 'Beverages', image: 'beverages.jpg' },
    { id: 5, name: 'Grocery', image: 'grocery.jpg' }
  ];
}
