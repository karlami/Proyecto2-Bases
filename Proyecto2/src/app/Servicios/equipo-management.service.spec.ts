import { TestBed } from '@angular/core/testing';

import { EquipoManagementService } from './equipo-management.service';

describe('EquipoManagementService', () => {
  let service: EquipoManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EquipoManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
