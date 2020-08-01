import { TestBed } from '@angular/core/testing';

import { EncuestaManagementService } from './encuesta-management.service';

describe('EncuestaManagementService', () => {
  let service: EncuestaManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EncuestaManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
