import { Component, OnInit } from '@angular/core';
import { Orders } from 'src/app/shared/Orders';
import { SalesDataService } from 'src/app/_services/SalesData.service';


@Component({
  selector: 'app-section-ordes',
  templateUrl: './section-ordes.component.html',
  styleUrls: ['./section-ordes.component.css']
})
export class SectionOrdesComponent implements OnInit {

  constructor(private _order: SalesDataService) { }

  orders: any[];
  total: number = 0;
  page: number = 1;
  limit: number = 8;
  loading: boolean = false;

  ngOnInit() {
    this.getOrders();
  }
  getOrders() {
    this._order.getData(this.page, this.limit).subscribe(o => {
      this.orders = o;
    });
  }
  goToPrevious(): void {
    this.page < 1 ? this.page = 1 : this.page--;
    console.log(this.page);
    this.getOrders();
  }
  goToNext(): void {
    this.page++;
    this.getOrders();
  }
}
