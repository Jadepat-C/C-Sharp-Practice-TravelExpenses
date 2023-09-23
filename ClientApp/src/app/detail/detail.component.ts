/**
 * Component for displaying details of a travel expense record.
 */
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

  /**
   * Constructor for DetailComponent.
   * @param route - The ActivatedRoute service to access route parameters.
   * @param router - The Router service for navigation.
   * @param location - The Location service for interacting with the browser's history.
   * @param travelExpensesService - The TravelExpensesService for fetching and deleting records.
   */
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private travelExpensesService: TravelExpensesService
  ) { }

  /**
   * Lifecycle hook called when the component is initialized.
   * Subscribes to route parameter changes to fetch data for a specific record.
   */
  ngOnInit(): void {
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

  /**
   * Handler for the delete button click.
   * Displays a confirmation dialog before proceeding with deletion.
   */
  delete(): void {
    const confirmation = window.confirm('Are you sure you want to delete this record? \nYou cannot undo this action.');

    if (confirmation) {
      // User clicked "OK," proceed with deletion
      this.performDelete();
    }
    // If the user clicked "Cancel," do nothing
  }

  /**
   * Perform the actual deletion of the record.
   * Deletes the record based on the 'id' parameter from the route.
   */
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
