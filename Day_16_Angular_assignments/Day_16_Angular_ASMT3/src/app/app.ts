import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Consumer } from "./components/consumer/consumer";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Consumer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Day_16_Angular_ASMT3');
}
