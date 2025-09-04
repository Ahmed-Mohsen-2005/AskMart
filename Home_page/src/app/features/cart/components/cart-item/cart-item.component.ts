import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common'; // ✅ import CommonModule for pipes
import { CartItemDto } from './cart-item.dto';

@Component({
  selector: 'app-cart-item',
  standalone: true,
  imports: [CommonModule], // ✅ register pipes here
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent {
  @Input() item!: CartItemDto;
  @Output() quantityChange = new EventEmitter<number>();
  @Output() remove = new EventEmitter<void>();

  increase() {
    this.quantityChange.emit(this.item.quantity + 1);
  }

  decrease() {
    if (this.item.quantity > 1) {
      this.quantityChange.emit(this.item.quantity - 1);
    } else {
      this.remove.emit();
    }
  }
}
