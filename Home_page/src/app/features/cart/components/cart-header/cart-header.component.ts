import { Component } from '@angular/core';
import { CartService } from '../../service/cart-service';

@Component({
  selector: 'app-cart-header',
  
  templateUrl: './cart-header.component.html',
  styleUrls: ['./cart-header.component.css']
})
export class CartHeaderComponent {
  constructor(private cartService: CartService) {}

  clearCart() {
    this.cartService.clearCart();
  }
}
