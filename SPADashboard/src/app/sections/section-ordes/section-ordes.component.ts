import { Component, OnInit } from '@angular/core';
import { Orders } from 'src/app/shared/Orders';


@Component({
  selector: 'app-section-ordes',
  templateUrl: './section-ordes.component.html',
  styleUrls: ['./section-ordes.component.css']
})
export class SectionOrdesComponent implements OnInit {

  constructor() { }

  orders: Orders[] = [
    {
      Customer: { Email: 'doe@email.com', Id: 1, Name: 'John Doe', State: 'CO' },
      Fulfilled: new Date(2019, 9, 8),
      Id: 2,
      Placed: new Date(2019, 8, 7),
      Total: 250,
      Status: 'Completed'
    },
    {
      Customer: { Email: 'doe@email.com', Id: 1, Name: 'John Doe', State: 'CO' },
      Fulfilled: new Date(2019, 11, 23),
      Id: 2,
      Placed: new Date(2019, 9, 17),
      Total: 250,
      Status: 'Completed'
    }
  ];

  ngOnInit() {
  }

}
