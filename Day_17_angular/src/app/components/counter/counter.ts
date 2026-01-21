import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-counter',
  imports: [],
  templateUrl: './counter.html',
  styleUrl: './counter.css',
})
export class Counter {
  counter = signal(0);
  incrementVal(){
    this.counter.update((val) => val + 1);
  }
  decrementVal(){
    this.counter.update((val) => val - 1);
  }
  resetVal(){
    this.counter.set(0);
  }
}
