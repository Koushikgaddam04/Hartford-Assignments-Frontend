import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListEmployees } from "./components/employees/list-employees";
import { Twoway } from "./components/twoway/twoway";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ListEmployees, Twoway],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Day_16_Angular');
}
