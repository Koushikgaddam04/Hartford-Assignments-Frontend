import { Component, input, output } from '@angular/core';
import { todotype } from '../../model/todotype';
import { HighlightCompletedTodo } from '../../directives/highlight-completed-todo';

@Component({
  selector: 'app-todo-items',
  imports: [HighlightCompletedTodo],
  templateUrl: './todo-items.html',
  styleUrl: './todo-items.css',
})
export class TodoItems {
todo = input.required<todotype>();
todoToggled = output<todotype>();
todoClicked(){
  this.todoToggled.emit(this.todo());
}  
}
