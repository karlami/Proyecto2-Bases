import { Component, OnInit } from '@angular/core';
import { Encuesta } from 'src/app/Modelos/encuesta.model';
import { EncuestaManagementService } from 'src/app/Servicios/encuesta-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-encuesta',
  templateUrl: './encuesta.component.html',
  styleUrls: ['./encuesta.component.css']
})
export class EncuestaComponent implements OnInit {

  encuestaList: Encuesta[];
  encuestaForm: NgForm;
  submitted = false;
  encuestaa: Encuesta;
  closeResult = '';

  constructor(public service: EncuestaManagementService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.generateForm();
  }

  generateForm(updateForm?: NgForm) {
    if (updateForm != null) {
      updateForm.reset();
    }
    this.encuestaa = {
        aseohospital: 3,
        tratopersonal: 3,
        puntualidad: 3
    };

  }


  onSubmit(encuestaForm: NgForm) {
    console.log('Ingresado');
    // console.log(this.service.postEncuesta(this.encuestaa));
    // this.service.postEncuesta(this.encuestaa);
    this.generateForm();
  }

}
