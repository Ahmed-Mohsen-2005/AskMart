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
    this.messages.push("You: " + this.newMessage);

    fetch("http://localhost:8000/chat", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ text: this.newMessage }),
    })
    .then(res => res.json())
    .then(data => {
      this.messages.push("Bot: " + data.reply);
    });

    this.newMessage = "";
  }
}
}
