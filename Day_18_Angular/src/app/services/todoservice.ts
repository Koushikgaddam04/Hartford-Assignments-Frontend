import { inject, Injectable } from '@angular/core';
import { todotype } from '../model/todotype';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class Todoservice {
  http = inject(HttpClient)
  todoItems: Array<todotype> = [{
    title:"groceries",
    id:1,
    userId: 1,
    completed:false
  },{
    title:'car wash',
    id:2,
    userId:2,
    completed:true
  }]

  getToDo(){
    return this.http.get<Array<todotype>>('https://jsonplaceholder.typicode.com/todos')
  }
}
