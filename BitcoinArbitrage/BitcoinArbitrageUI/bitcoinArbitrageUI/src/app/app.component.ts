import { Component, NgModule, OnInit } from '@angular/core';
import { ApiService } from './services/api.service';
import { ArbitrageData } from './models/bitcoinArbitrage.models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public filters = [{name: 'Latest 100', value: 1},
  {name: 'Latest 1000', value: 2},
  {name: 'Latest 10000', value: 3},
  {name: 'Latest 100000', value: 4}];
  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public myResults: ArbitrageData[] = [];
  public showNow = false;

  public barChartLabels = [];
  public barChartType = 'line';
  public barChartLegend = true;
  public barChartData = [
    {data: [],
    label: 'Kraken, Bitcoin in ZAR',
    fill: false
  },
  {data: [],
    label: 'Luno, Bitcoin in ZAR',
    fill: false
  }
  ];

  public barChartDataPercent = [
    {data: [],
    label: 'Percentage Profit Before Cost',
    fill: false
  }
  ];
  constructor(private myService: ApiService) {
  }

  getData() {
    const xs = [];
    const ks = [];
    const percents = [];
    let temp = 0.0;
    this.myResults.forEach(element => {
      xs.push(element.lunoXBTZAR);
      temp = element.krakenXBTEUR * element.eurzar;
      ks.push(temp);
      percents.push(element.percentageProfitBeforeCost);
    });

    this.barChartData = [
      {data: ks,
      label: 'Kraken Bitcoin in ZAR',
      fill: false
    },
    {data: xs,
      label: 'Luno Bitcoin in ZAR',
      fill: false
    }
    ];

    this.barChartDataPercent = [
      {data: percents,
      label: 'Percentage Profit Before Cost',
      fill: false
    }
    ];
  }

  getTime(myDate: Date) {
    const t = new Date(myDate);
    const date = ('0' + t.getDate()).slice(-2);
    // const month = ('0' + (t.getMonth() + 1)).slice(-2);
    // const year = t.getFullYear();
    const hours = ('0' + t.getHours()).slice(-2);
    const minutes = ('0' + t.getMinutes()).slice(-2);
    return `${date}th, ${hours}:${minutes}`;
  }
  getChartLabels() {
    const ys = [];
    this.myResults.forEach(element => {
     // ys.push(new Date(element.dateCaptured).toLocaleDateString());
     ys.push(this.getTime(element.dateCaptured));
    });
    this.barChartLabels = ys;
  }
  ngOnInit() {
    this.get1000();
  }
  changeData(i) {
    console.log(i);
    if (i === 1) {
      this.get100();
    } else if (i === 2) {
      this.get1000();
    } else if (i === 3) {
      this.get10000();
    } else if (i === 4) {
      this.get100000();
    }
  }

  get100() {
    this.myService.getFirst100().subscribe(a => {
      console.log(a);
      this.myResults = a;
      console.log(this.myResults);
      this.getData();
      this.getChartLabels();
      this.showNow = true;
    });
  }
  get1000() {
    this.myService.getFirst1000().subscribe(a => {
      console.log(a);
      this.myResults = a;
      console.log(this.myResults);
      this.getData();
      this.getChartLabels();
      this.showNow = true;
    });
  }
  get10000() {
    this.myService.getFirst10000().subscribe(a => {
      console.log(a);
      this.myResults = a;
      console.log(this.myResults);
      this.getData();
      this.getChartLabels();
      this.showNow = true;
    });
  }
  get100000() {
    this.myService.getFirst100000().subscribe(a => {
      console.log(a);
      this.myResults = a;
      console.log(this.myResults);
      this.getData();
      this.getChartLabels();
      this.showNow = true;
    });
  }
}
