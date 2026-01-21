import { Component } from '@angular/core';
import { Calculator } from '../../services/calculator';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-consumer',
  imports: [FormsModule],
  templateUrl: './consumer.html',
  styleUrl: './consumer.css',
})
export class Consumer {
  a: number = 30;
  b: number = 40;
  ans: number = 0;

  //inject service to constructor
  constructor(private Calci: Calculator){}

  //use the service
  addNum(){
    this.ans = this.Calci.add(this.a, this.b);
  }

  subNum(){
    this.ans = this.Calci.sub(this.a, this.b);
  }

  mulNum(){
    this.ans = this.Calci.mul(this.a, this.b);
  }

  divNum(){
    this.ans = this.Calci.div(this.a, this.b);
  }
}
