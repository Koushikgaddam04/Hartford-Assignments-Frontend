import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Servicecomp {
  constructor(private http: HttpClient) {}

  // Fetch todos from the API
  getToDo(): Observable<any[]> {
    return this.http.get<any[]>('https://jsonplaceholder.typicode.com/todos');
  }
  getToDoById(id:string){
    return this.http.get<any>(`https://jsonplaceholder.typicode.com/todos/${id}`)
  }
}