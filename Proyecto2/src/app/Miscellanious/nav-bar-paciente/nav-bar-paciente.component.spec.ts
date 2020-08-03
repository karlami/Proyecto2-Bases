import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBarPacienteComponent } from './nav-bar-paciente.component';

describe('NavBarPacienteComponent', () => {
  let component: NavBarPacienteComponent;
  let fixture: ComponentFixture<NavBarPacienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavBarPacienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavBarPacienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
