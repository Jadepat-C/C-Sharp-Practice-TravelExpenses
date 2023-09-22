import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { TravelExpensesDTO } from './travel-expenses';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TravealExpensesServiceService {
  public dataset: TravelExpensesDTO[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    // Update the URL to match your ASP.NET Core API endpoint
    const apiUrl = baseUrl + 'travelexpenses'; // Assuming 'api/' is your API route prefix

    http.get<TravelExpensesDTO[]>(apiUrl).subscribe(
      (result) => {
        this.dataset = result;
        console.log('Data received:', this.dataset); // Log received data
      },
      (error) => {
        console.error('HTTP Error:', error); // Log HTTP error
      }
    );
  }

  /*getDetails(): Observable<TravelExpensesDTO> {
    const detail = of()
    return 
  }*/
  getDetail(id: number): Observable<TravelExpensesDTO> {
    const detail = this.dataset.find(d => d.id = id)!;
    return of(detail);
  }
}
