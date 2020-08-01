import { TestBed } from '@angular/core/testing';

import { ReservacionManagementService } from './reservacion-management.service';

describe('ReservacionManagementService', () => {
  let service: ReservacionManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReservacionManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
