import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginPacienteComponent } from './login-paciente.component';

describe('LoginPacienteComponent', () => {
  let component: LoginPacienteComponent;
  let fixture: ComponentFixture<LoginPacienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginPacienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginPacienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
