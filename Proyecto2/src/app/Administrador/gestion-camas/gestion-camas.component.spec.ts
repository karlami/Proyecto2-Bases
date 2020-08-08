import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionCamasComponent } from './gestion-camas.component';

describe('GestionCamasComponent', () => {
  let component: GestionCamasComponent;
  let fixture: ComponentFixture<GestionCamasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionCamasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionCamasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
