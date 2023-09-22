import { TestBed } from '@angular/core/testing';

import { TravelExpensesServiceService } from './travel-expenses-service.service';

describe('TravelExpensesServiceService', () => {
  let service: TravelExpensesServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TravelExpensesServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
