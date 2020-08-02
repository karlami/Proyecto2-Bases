import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/Modelos/paciente.model';
import { Pacientep } from 'src/app/Modelos/pacientep.model';
import { PacienteManagementService } from 'src/app/Servicios/paciente-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-agregar-paciente',
  templateUrl: './agregar-paciente.component.html',
  styleUrls: ['./agregar-paciente.component.css']
})
export class AgregarPacienteComponent implements OnInit {

  camaList: Paciente[];
  camaForm: NgForm;
  updateForm: NgForm;
  submitted = false;
  pacientee: Pacientep;
  closeResult = '';

  constructor(public service: PacienteManagementService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.generateForm();
  }


  generateForm(updateForm?: NgForm) {
    if (updateForm != null) {
      updateForm.reset();
    }
    this.pacientee = {
        nombre: '',
        primerapellido: '',
        segundoapellido: '',
        cedula: 1,
        telefono: 1,
        direccion: '',
        fechanacimiento: new Date('Ene 01 2020'),
        patologias: 1,
        tratamientos: '',
        contrasena: ''
    };

  }

  onSubmit(pacienteForm: NgForm) {
    console.log('Ingresado');
    console.log(this.service.postPacientes(this.pacientee));
    this.service.postPacientes(this.pacientee);
    this.generateForm();
  }

}

