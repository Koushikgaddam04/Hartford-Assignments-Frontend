import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Greeting } from "../components/greeting/greeting";
import { Counter } from '../components/counter/counter';
import { count } from 'rxjs';
@Component({
  selector: 'app-header',
  imports: [FormsModule, Greeting, Counter],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header {
  hello = '';
  title = signal('Some title');
  clickHandler(){
    console.log("User Clicked");
  }
  keyclick(event: KeyboardEvent){
    console.log(`Key pressed - ${event.key} key`);
  }
}
