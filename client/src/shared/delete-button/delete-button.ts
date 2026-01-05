import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-delete-button',
  imports: [],
  templateUrl: './delete-button.html',
  styleUrl: './delete-button.css',
})
export class DeleteButton {
  disabled = input<boolean>(false);
  clickEvent = output<void>();

  onClick(event: Event) {
    event.stopPropagation();
    event.preventDefault();
    this.clickEvent.emit();
  }
}
