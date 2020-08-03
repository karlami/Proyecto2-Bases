import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomePacienteComponent } from './welcome-paciente.component';

describe('WelcomePacienteComponent', () => {
  let component: WelcomePacienteComponent;
  let fixture: ComponentFixture<WelcomePacienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WelcomePacienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomePacienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
