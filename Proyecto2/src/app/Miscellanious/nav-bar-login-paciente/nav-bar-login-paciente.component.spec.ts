import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBarLoginPacienteComponent } from './nav-bar-login-paciente.component';

describe('NavBarLoginPacienteComponent', () => {
  let component: NavBarLoginPacienteComponent;
  let fixture: ComponentFixture<NavBarLoginPacienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavBarLoginPacienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavBarLoginPacienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
