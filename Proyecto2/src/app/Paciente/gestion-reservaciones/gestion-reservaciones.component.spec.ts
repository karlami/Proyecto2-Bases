import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionReservacionesComponent } from './gestion-reservaciones.component';

describe('GestionReservacionesComponent', () => {
  let component: GestionReservacionesComponent;
  let fixture: ComponentFixture<GestionReservacionesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionReservacionesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionReservacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
