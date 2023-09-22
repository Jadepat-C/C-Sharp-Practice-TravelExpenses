// Angular Component for Viewing Records
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TravelExpensesDTO } from '../travel-expenses';
import { Router } from '@angular/router';
import { TravelExpensesService } from '../../services/travel-expenses.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  // Array to store retrieved records
  public dataset: TravelExpensesDTO[] = [];

  // Selected record
  selectedInstance?: TravelExpensesDTO;

  // Current page number
  currentPage: number = 1;

  // Number of items to display per page
  itemsPerPage: number = 50;

  // Last page number
  lastPage: number = 1;

  // Calculate the total number of pages
  totalPages(): number {
    return Math.ceil(this.dataset.length / this.itemsPerPage);
  }

  // Generate an array of page numbers for display
  pageNumbers(): number[] {
    const pages = [];
    const totalPages = this.totalPages();
    for (let i = 1; i <= totalPages; i++) {
      pages.push(i);
    }
    return pages;
  }

  // Calculate the range of visible page numbers
  visiblePageNumbers(): number[] {
    const total = this.totalPages();
    const range = 5; // Number of page numbers to show on each side of the current page
    const start = Math.max(1, this.currentPage - range);
    const end = Math.min(total, this.currentPage + range);
    const pages = [];

    for (let i = start; i <= end; i++) {
      pages.push(i);
      if (pages.length > range + 1) {
        pages.shift();
      }
    }

    return pages;
  }

  // Navigate to the specified page
  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages()) {
      this.currentPage = page;
    }
  }

  // Calculate the starting index of displayed instances
  startIndex(): number {
    return (this.currentPage - 1) * this.itemsPerPage;
  }

  // Calculate the ending index of displayed instances
  endIndex(): number {
    const endIndex = this.startIndex() + this.itemsPerPage;
    return endIndex > this.dataset.length ? this.dataset.length : endIndex;
  }

  // Return the instances to display on the current page
  displayedInstances(): TravelExpensesDTO[] {
    return this.dataset.slice(this.startIndex(), this.endIndex());
  }

  // Select a record instance
  selectInstance(instance: TravelExpensesDTO): void {
    this.selectedInstance = instance;
    this.router.navigate(['/detail', instance.id]);
  }

  // Constructor to initialize data
  constructor(
    private router: Router,
    http: HttpClient,
    private travelExpensesService: TravelExpensesService
  ) {
    this.getData();
  }

  // Retrieve data from the service
  getData() {
    this.travelExpensesService.get().subscribe(
      (result) => {
        this.dataset = result;
        this.lastPage = this.totalPages(); // Update lastPage when new data is received
      },
      (error) => {
        console.error('HTTP Error:', error);
      });
  }

  // Move to the next page
  nextPage(): void {
    if (this.currentPage < this.lastPage) {
      this.currentPage++;
    }
  }

  // Move to the previous page
  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  // Move to the first page
  goFirst(): void {
    this.currentPage = 1;
  }

  // Move to the last page
  goLast(): void {
    this.currentPage = this.lastPage;
  }
}
