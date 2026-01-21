import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Usercomponent } from "./components/usercomponent/usercomponent";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Usercomponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Day_16_Angular_ASMT2');
}
