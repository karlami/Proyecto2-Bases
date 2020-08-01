import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionEquipoComponent } from './gestion-equipo.component';

describe('GestionEquipoComponent', () => {
  let component: GestionEquipoComponent;
  let fixture: ComponentFixture<GestionEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
