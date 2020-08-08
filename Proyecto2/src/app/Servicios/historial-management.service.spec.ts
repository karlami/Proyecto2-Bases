import { TestBed } from '@angular/core/testing';

import { HistorialManagementService } from './historial-management.service';

describe('HistorialManagementService', () => {
  let service: HistorialManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HistorialManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
