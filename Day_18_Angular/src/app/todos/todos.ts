import { Component, inject, OnInit, signal } from '@angular/core';
import { Todoservice } from '../services/todoservice';
import { todotype } from '../model/todotype';
import { TodoItems } from '../components/todo-items/todo-items';
@Component({
  selector: 'app-todos',
  imports: [TodoItems],
  templateUrl: './todos.html',
  styleUrl: './todos.css',
})
export class Todos implements OnInit{
  todoservice = inject(Todoservice);
  todoItems = signal<Array<todotype>>([]);
  ngOnInit(): void {
    console.log(this.todoservice.todoItems);
    this.todoservice.getToDo().subscribe((todos)=>{
      this.todoItems.set(todos);
    })
  }

  updateTodoItem(){}
}
