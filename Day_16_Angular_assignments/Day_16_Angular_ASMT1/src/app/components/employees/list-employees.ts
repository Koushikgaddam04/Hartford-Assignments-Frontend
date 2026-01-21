import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { DatePipe } from '@angular/common'; 

@Component({
  selector: 'app-list-employees',
  standalone:true,
  imports: [DatePipe],
  templateUrl: './list-employees.html',
  styleUrl: './list-employees.css',
})

export class ListEmployees  implements OnInit{
  employees:Employee[]=[
    {
      id:1,
      name:'Nanda Kishore',
      gender:'Male',
      contactPreference:'Email',
      email:'Nandakishore@gmail.com',
      dateOfBirth:new Date('01/07/2004'),
      isActive:true,
      department:'CSE',
      photoPath:'emp1.webp'
    },
     {
      id:2,
      name:'Ruthvik',
      gender:'Male',
      contactPreference:'Email',
      email:'ruthvik@gmail.com',
      dateOfBirth:new Date('01/07/2004'),
      isActive:true,
      department:'AIML',
      photoPath:'emp2.webp'
    },
     {
      id:3,
      name:'Mani',
      gender:'Male',
      contactPreference:'Email',
      email:'ManiRathnam@gmail.com',
      dateOfBirth:new Date('01/07/2004'),
      isActive:true,
      department:'IT',
      photoPath:'emp3.webp'
    },
  ];
  constructor(){}
  ngOnInit(){
  }
}