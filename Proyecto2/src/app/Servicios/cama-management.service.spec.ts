import { TestBed } from '@angular/core/testing';

import { CamaManagementService } from './cama-management.service';

describe('CamaManagementService', () => {
  let service: CamaManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CamaManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
