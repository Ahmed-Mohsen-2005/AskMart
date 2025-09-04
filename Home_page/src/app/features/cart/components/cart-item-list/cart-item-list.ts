import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from '../../service/cart-service';
import { CartItemDto } from '../cart-item/cart-item.dto';
import { CartItemComponent } from '../cart-item/cart-item.component';

@Component({
  selector: 'app-cart-item-list',
  standalone: true,
  imports: [CommonModule, CartItemComponent],
  templateUrl: './cart-item-list.html',
  styleUrls: ['./cart-item-list.css']
})
export class CartItemListComponent {
  items$; // declare first

  constructor(private cartService: CartService) {
    this.items$ = this.cartService.items$; // assign here
  }

  onQuantityChange(id: number, quantity: number) {
    this.cartService.updateQuantity(id, quantity);
  }

  onRemove(id: number) {
    this.cartService.removeItem(id);
  }
}
