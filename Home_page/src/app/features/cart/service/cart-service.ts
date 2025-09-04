import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { CartItemDto } from '../components/cart-item/cart-item.dto';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private itemsSubject = new BehaviorSubject<CartItemDto[]>([]);
  items$ = this.itemsSubject.asObservable();

  // Reactive total
  total$ = this.items$.pipe(
    map(items => items.reduce((acc, i) => acc + i.price * i.quantity, 0))
  );

  // Get current snapshot
  get items(): CartItemDto[] {
    return this.itemsSubject.value;
  }

  addItem(item: CartItemDto) {
    const existing = this.items.find(i => i.id === item.id);

    let updated: CartItemDto[];

    if (existing) {
      // Create a new updated array (avoid mutation)
      updated = this.items.map(i =>
        i.id === item.id ? { ...i, quantity: i.quantity + 1 } : i
      );
    } else {
      updated = [...this.items, { ...item, quantity: 1 }];
    }

    this.itemsSubject.next(updated);
  }

  updateQuantity(id: number, quantity: number) {
    const updated = this.items.map(i =>
      i.id === id ? { ...i, quantity } : i
    );
    this.itemsSubject.next(updated);
  }

  removeItem(id: number) {
    const updated = this.items.filter(i => i.id !== id);
    this.itemsSubject.next(updated);
  }

  clearCart() {
    this.itemsSubject.next([]);
  }

  // Optional: keep this if you want direct calculation (non-reactive)
  getTotal(): number {
    return this.items.reduce((acc, item) => acc + item.price * item.quantity, 0);
  }
}
