import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Todoservice } from '../../services/todoservice';

@Component({
  selector: 'app-header',
  imports: [RouterLink],
  templateUrl: './header.html',
  styleUrl: './header.css',
  providers:[Todoservice]
})
export class Header {

}
