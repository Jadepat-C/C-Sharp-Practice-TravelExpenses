// Import necessary modules and components
import { Component, OnInit, Input, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TravelExpensesDTO } from '../travel-expenses';
import { Location } from '@angular/common';
import { TravelExpensesService } from '../../services/travel-expenses.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  @Input() selectedInstance?: TravelExpensesDTO;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private travelExpensesService: TravelExpensesService
  ) { }

  // This method is automatically called when the component is initialized
  ngOnInit(): void {
    // Subscribe to route parameter changes to fetch data for a specific record
    this.route.params.subscribe(params => {
      const id = params['id']; // Get the 'id' parameter from the URL

      // Use the TravelExpensesService to fetch the record by ID
      this.travelExpensesService.getByID(id).subscribe(
        (result) => {
          this.selectedInstance = result;
        },
        (error) => {
          console.error('HTTP Error:', error);
        }
      );
    });
  }

  // Handler for the delete button click
  delete(): void {
    const confirmation = window.confirm('Are you sure you want to delete this record? \nYou cannot undo this action.');

    if (confirmation) {
      // User clicked "OK," proceed with deletion
      this.performDelete();
    }
    // If the user clicked "Cancel," do nothing
  }

  // Perform the actual deletion of the record
  performDelete(): void {
    this.route.params.subscribe(params => {
      const id = params['id']; // Get the 'id' parameter from the URL

      // Use the TravelExpensesService to delete the record by ID
      this.travelExpensesService.delete(id).subscribe(
        (response) => {
          window.alert("Record deleted");
          console.info('Response:', response)
          this.router.navigate(['/']);
        },
        (error) => {
          console.error('HTTP Error:', error);
        }
      );
    });
  }
}
