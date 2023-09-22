import { TestBed } from '@angular/core/testing';

import { TravealExpensesServiceService } from './traveal-expenses-service.service';

describe('TravealExpensesServiceService', () => {
  let service: TravealExpensesServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TravealExpensesServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
