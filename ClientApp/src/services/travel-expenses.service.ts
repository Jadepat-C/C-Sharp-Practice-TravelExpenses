import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { Observable } from 'rxjs/internal/Observable';
import { TravelExpensesDTO } from '../app/travel-expenses';


@Injectable({
  providedIn: 'root'
})
export class TravelExpensesService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string // Inject BASE_URL

  ) { }

  delete(id: number) {
    return this.http.delete(this.baseUrl + 'travelexpenses/delete/' + id, { responseType: 'text' });
  }

  update(updateItem: TravelExpensesDTO) {
    return this.http.post(this.baseUrl + 'travelexpenses/update/' + updateItem.id, updateItem, { responseType: 'text' });
  }

  get() {
    return this.http.get<TravelExpensesDTO[]>(this.baseUrl + 'travelexpenses/get');
  }

  getByID(id: number) {
    return this.http.get<TravelExpensesDTO>(this.baseUrl + 'travelexpenses/get/' + id);
  }

  insert(insertItem: TravelExpensesDTO) {
    return this.http.post(this.baseUrl + 'travelexpenses/insert/', insertItem, { responseType: 'text' });
  }

/*  delete1(id: number): Observable<any[]> {
    return this.http.delete(this.baseUrl + 'travelexpenses/delete/' + id)
      .pipe(map((response: Response)=<any[]>response.json()));
  }*/
}
