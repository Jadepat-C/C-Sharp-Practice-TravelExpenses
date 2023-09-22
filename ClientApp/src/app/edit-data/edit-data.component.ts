// Import necessary modules and components
import { Component, OnInit, Input, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TravelExpensesDTO } from '../travel-expenses';
import { HttpClient } from '@angular/common/http';
import { Location } from '@angular/common';
import { DatePipe } from '@angular/common';
import { TravelExpensesService } from '../../services/travel-expenses.service';

@Component({
  selector: 'app-edit-data',
  templateUrl: './edit-data.component.html',
  styleUrls: ['./edit-data.component.css']
})
export class EditDataComponent implements OnInit {
  @Input() selectedInstance?: TravelExpensesDTO;

  // Declare variables to hold form field values
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
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private http: HttpClient, // Inject HttpClient
    @Inject('BASE_URL') private baseUrl: string, // Inject BASE_URL
    private datePipe: DatePipe,
    private travelExpensesService: TravelExpensesService
  ) { }

  // This method is automatically called when the component is initialized
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id']; // Get the 'id' parameter from the URL
      const apiUrl = `${this.baseUrl}travelexpenses/get/${id}`; // Build the API URL with the ID

      // Make an HTTP GET request to fetch the specific travel expense by ID
      this.http.get<TravelExpensesDTO>(apiUrl).subscribe(
        (result) => {
          this.selectedInstance = result; // Assign the fetched data to selectedInstance
          console.log('Data received:', this.selectedInstance);

          // Populate form fields with fetched data
          this.ref_number = this.selectedInstance.ref_number;
          this.title = this.selectedInstance.title_en;
          this.purpose = this.selectedInstance.purpose_en;
          this.start_date = this.selectedInstance.start_date ? this.datePipe.transform(this.selectedInstance.start_date, 'yyyy-MM-dd')! : '';
          this.end_date = this.selectedInstance.end_date ? this.datePipe.transform(this.selectedInstance.end_date, 'yyyy-MM-dd')! : '';
          this.airfare = this.selectedInstance.airfare;
          this.other_transport = this.selectedInstance.other_transport;
          this.meals = this.selectedInstance.meals;
          this.other_expenses = this.selectedInstance.other_expenses;
          this.calculateTotal();
        },
        (error) => {
          console.error('HTTP Error:', error);
        }
      );
    });
  }

  // Calculate the total expense
  public calculateTotal(): void {
    this.total = this.airfare + this.other_transport + this.meals + this.other_expenses;
  }

  // Handle cancel button click to go back
  public cancel(): void {
    this.location.back();
  }

  // Handle update button click to update the record
  public update(): void {
    this.route.params.subscribe(params => {
      const id = params['id']; // Get the 'id' parameter from the URL

      // Create an update object with form field values
      const updateItem: TravelExpensesDTO = {
        id: id,
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

      // Use the TravelExpensesService to update the record
      this.travelExpensesService.update(updateItem).subscribe(
        (response) => {
          console.log('Record updated successfully:', response);
          window.alert("Record Updated");
          this.router.navigate([`/detail/${updateItem.id}`]);
        },
        (error) => {
          console.error('HTTP Error:', error);
        }
      );
    });
  }
}
