import { TestBed } from '@angular/core/testing';

import { ProcedimientoManagementService } from './procedimiento-management.service';

describe('ProcedimientoManagementService', () => {
  let service: ProcedimientoManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProcedimientoManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
