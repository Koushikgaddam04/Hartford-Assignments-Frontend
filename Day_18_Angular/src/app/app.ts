import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// import { Home } from "./home/home";
// import { Greeting } from "./components/greeting/greeting";
import { Header } from "./components/header/header";
import { Parent } from "./components/parent/parent";
import { Todos } from "./todos/todos";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Parent, Todos],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('test-app');
}
