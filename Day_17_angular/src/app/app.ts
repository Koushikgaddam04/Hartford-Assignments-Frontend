import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from "./header/header";
import { ToDoList } from "./components/to-do-list/to-do-list";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, ToDoList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('test-app');
}
