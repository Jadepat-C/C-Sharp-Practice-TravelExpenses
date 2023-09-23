/**
 * TypeScript Component for Inserting New Travel Expense Records.
 */
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { TravelExpensesService } from '../../services/travel-expenses.service';
import { TravelExpensesDTO } from '../travel-expenses';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-insert-data',
  templateUrl: './insert-data.component.html',
  styleUrls: ['./insert-data.component.css']
})
export class InsertDataComponent implements OnInit {
  constructor(
    private http: HttpClient,
    private location: Location,
    private travelExpensesService: TravelExpensesService,
    private router: Router
  ) { }

  @ViewChild('myForm') myForm!: NgForm;

  ngOnInit(): void {
  }

  // Form input fields
  public ref_number: string = "";
  public title: string = "";
  public purpose: string = "";
  public start_date: string = "";
  public end_date: string = "";
  public airfare: number = 0;
  public other_transport: number = 0;
  public lodging: number = 0;
  public meals: number = 0;
  public other_expenses: number = 0;
  public total: number = 0;

  /**
   * Calculate the total expense based on form input fields.
   */
  public calculateTotal() {
    this.total = this.airfare + this.other_transport + this.lodging +this.meals + this.other_expenses;
  }

  /**
   * Reset all form input fields to their initial values.
   */
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

  /**
   * Submit the form and insert a new travel expense record.
   */
  public submit() {
    // Check if the "Ref Number" field is valid
    if (this.myForm.controls['ref_number'].valid) {
      // Create a TravelExpensesDTO object based on form data
      const travelExpenses: TravelExpensesDTO = {
        ref_number: this.ref_number,
        title_en: this.title,
        purpose_en: this.purpose,
        start_date: this.start_date,
        end_date: this.end_date,
        airfare: this.airfare,
        other_transport: this.other_transport,
        lodging: this.lodging,
        meals: this.meals,
        other_expenses: this.other_expenses,
        total: this.total
      };

      // Insert the new record
      this.travelExpensesService.insert(travelExpenses).subscribe(
        (response) => {
          this.reset();
          console.info('Response:', response)
          window.alert("Record created");
          this.router.navigate(['/']);
        },
        (error) => {
          console.error('Error:', error);
        }
      );
    } else {
      // Display an error message for the "Ref Number" field
      this.myForm.controls['ref_number'].markAsTouched();
      window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
      });
    }
  }
}
