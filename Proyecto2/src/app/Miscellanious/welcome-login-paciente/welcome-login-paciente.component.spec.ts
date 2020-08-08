import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeLoginPacienteComponent } from './welcome-login-paciente.component';

describe('WelcomeLoginPacienteComponent', () => {
  let component: WelcomeLoginPacienteComponent;
  let fixture: ComponentFixture<WelcomeLoginPacienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WelcomeLoginPacienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeLoginPacienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
