import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteAreaMejoraComponent } from './reporte-area-mejora.component';

describe('ReporteAreaMejoraComponent', () => {
  let component: ReporteAreaMejoraComponent;
  let fixture: ComponentFixture<ReporteAreaMejoraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReporteAreaMejoraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteAreaMejoraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
