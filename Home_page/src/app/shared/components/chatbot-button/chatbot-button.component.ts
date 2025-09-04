import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';   // ngIf, ngFor
import { FormsModule } from '@angular/forms';     // ngModel

@Component({
  selector: 'app-chatbot-button',
  standalone: true,  // ✅ important for imports to work
  imports: [CommonModule, FormsModule],
  templateUrl: './chatbot-button.component.html',
  styleUrls: ['./chatbot-button.component.css']   // ✅ plural
})
export class ChatbotButton {
  isOpen = false;
  messages: string[] = [];
  newMessage = '';

  toggleChat() {
    this.isOpen = !this.isOpen;
  }

  sendMessage() {
    if (this.newMessage.trim()) {
      this.messages.push(this.newMessage.trim());
      this.newMessage = '';
    }
  }
}
