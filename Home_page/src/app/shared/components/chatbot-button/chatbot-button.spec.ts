import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatbotButton } from './chatbot-button.component';

describe('ChatbotButton', () => {
  let component: ChatbotButton;
  let fixture: ComponentFixture<ChatbotButton>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChatbotButton]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChatbotButton);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
