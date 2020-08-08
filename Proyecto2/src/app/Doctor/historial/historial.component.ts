import { Component, OnInit } from '@angular/core';
import { Historialp } from 'src/app/Modelos/historialp.model';
import { HistorialManagementService } from 'src/app/Servicios/historial-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-historial',
  templateUrl: './historial.component.html',
  styleUrls: ['./historial.component.css']
})
export class HistorialComponent implements OnInit {

  historialList: Historialp[];
  historialForm: NgForm;
  submitted = false;
  historiall: Historialp;
  closeResult = '';

  constructor(public service: HistorialManagementService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.generateForm();
  }

  // metodo para generar el formulario
  generateForm(historialForm?: NgForm) {
    if (historialForm != null) {
      historialForm.reset();
    }
    this.historiall = {
        cedula: undefined,
        idprocedimiento: undefined,
        tratamiento: '',
        fechaingreso: new Date('2020 01 01')
    };

  }

// metodo para hacer post
  onSubmit(historialForm: NgForm) {
    console.log('Ingresado');
    // console.log(this.service.postEncuesta(this.encuestaa));
    // this.service.postEncuesta(this.encuestaa);
    this.generateForm();
  }

}
