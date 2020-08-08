import { TestBed } from '@angular/core/testing';

import { DireccionManagementService } from './direccion-management.service';

describe('DireccionManagementService', () => {
  let service: DireccionManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DireccionManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
