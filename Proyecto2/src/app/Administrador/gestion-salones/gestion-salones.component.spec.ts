import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionSalonesComponent } from './gestion-salones.component';

describe('GestionSalonesComponent', () => {
  let component: GestionSalonesComponent;
  let fixture: ComponentFixture<GestionSalonesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionSalonesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionSalonesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
