import { TestBed } from '@angular/core/testing';

import { SalonManagementService } from './salon-management.service';

describe('SalonManagementService', () => {
  let service: SalonManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalonManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
