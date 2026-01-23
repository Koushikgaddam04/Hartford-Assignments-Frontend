import { Component, EventEmitter, input, Output} from '@angular/core';

@Component({
  selector: 'app-child',
  imports: [],
  templateUrl: './child.html',
  styleUrl: './child.css',
})
export class Child {
  @Output() datachanged = new EventEmitter<string>();
  sendDataToParent(data:string){
    this.datachanged.emit(data);
  }
  msg = input("this is from child");
}
