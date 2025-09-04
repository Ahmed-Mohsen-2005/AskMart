import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-filter',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-filter.component.html',
  styleUrl: './product-filter.component.css'
})
export class ProductFilter {
  categories: string[] = ['All', 'Fruits', 'Vegetables', 'Bakery', 'Beverages', 'Grocery', 'Dairy'];
  selectedCategory = 'All';
  searchText = '';

  @Output() filterChanged = new EventEmitter<{ category: string; search: string }>();

  applyFilter() {
    this.filterChanged.emit({ category: this.selectedCategory, search: this.searchText });
  }
}
