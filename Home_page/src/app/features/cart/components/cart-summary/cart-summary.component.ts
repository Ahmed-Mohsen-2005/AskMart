import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from '../../service/cart-service';
import { CartSummaryDto } from './cart-summary.dto';

@Component({
  selector: 'app-cart-summary',
  standalone: true, // ✅ if using standalone
  imports: [CommonModule],
  templateUrl: './cart-summary.component.html', // ✅ correct template
  styleUrls: ['./cart-summary.component.css']
})
export class CartSummaryComponent implements OnInit {
  summary: CartSummaryDto = { total: 0, deliveryTimeMins: 25 };

  constructor(private cartService: CartService) {}

  ngOnInit() {
    this.cartService.items$.subscribe(() => {
      this.summary = {
        total: this.cartService.getTotal(),
        deliveryTimeMins: 25
      };
    });
  }
}
