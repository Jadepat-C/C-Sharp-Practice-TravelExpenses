import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TravelExpensesDTO } from '../travel-expenses';
import { Location } from '@angular/common';
import { TravelExpensesService } from '../../services/travel-expenses.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public ref_number: string = "";
  public title: string = "";
  public purpose: string = "";
  public start_date: string = "";
  public end_date: string = "";
  public airfare: number = 0;
  public other_transport: number = 0;
  public meals: number = 0;
  public other_expenses: number = 0;
  public total: number = 0;

  constructor(
    private http: HttpClient,
    private location: Location,
    private travelExpensesService: TravelExpensesService
  ) { }

  public calculateTotal() {
    this.total = this.airfare + this.other_transport + this.meals + this.other_expenses;
  }
  public reset() {
    this.ref_number = "";
    this.title = "";
    this.purpose = "";
    this.start_date = "";
    this.end_date = "";
    this.airfare = 0;
    this.other_transport = 0;
    this.meals = 0;
    this.other_expenses = 0;
  }

  public submit() {
    // Create a TravelExpensesDTO object based on your form data
    const travelExpenses: TravelExpensesDTO = {
      ref_number: this.ref_number,
      title_en: this.title,
      purpose_en: this.purpose,
      start_date: this.start_date,
      end_date: this.end_date,
      airfare: this.airfare,
      other_transport: this.other_transport,
      meals: this.meals,
      other_expenses: this.other_expenses,
      total: this.total
    };

    this.travelExpensesService.insert(travelExpenses).subscribe(
      (respond) => {
        this.reset();
        window.alert("Record created");
        this.location.back();
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }
}
