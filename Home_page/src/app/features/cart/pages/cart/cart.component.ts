import { Component } from '@angular/core';
import { CartHeaderComponent } from '../../components/cart-header/cart-header.component';
import { CartItemListComponent } from '../../components/cart-item-list/cart-item-list';
import { CartSummaryComponent } from '../../components/cart-summary/cart-summary.component';

@Component({
  selector: 'app-cart',
  standalone: true,
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  
})
export class CartComponent {}
