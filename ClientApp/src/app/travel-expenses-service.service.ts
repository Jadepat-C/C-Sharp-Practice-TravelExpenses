import { Component, OnInit } from '@angular/core';
/*import { TravelExpensesService } from './travel-expenses.service';*/

@Component({
  selector: 'app-my-component',
  templateUrl: './my-component.component.html',
})
export class MyComponent implements OnInit {
  dataset: TravelExpensesDTO[];

  constructor(private travelExpensesService: TravelExpensesService) { }

  ngOnInit(): void {
    this.travelExpensesService.getAll().subscribe((data) => {
      this.dataset = data;
      // Now, 'this.dataset' contains the data returned by your C# GetAll() method
    });
  }
}

interface TravelExpensesDTO {
  id: number;
  ref_number: string;
  title: string;
  purpose: string;
  start_date: string;
  end_date: string;
  airfare: number;
  other_transportation: number;
  meals: number;
  total: number
}
