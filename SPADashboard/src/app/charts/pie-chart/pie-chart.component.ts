import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {

  constructor() { }
  public pieChartData: number[] = [350, 450, 120];
  public pieChartLabel: string[] = ['XYZ Logistic', 'Main St Bakery', 'Acme Hosting'];
  public pieChartType = 'doughnut';
  public pieChartLegend = true;
  public colors: any[] = [
    {
      backgroundColor: ['#26547c', '#ff6b6b', '#ffd166'],
      borderColor: '#111'
    }
  ];

  ngOnInit() {
  }

}
