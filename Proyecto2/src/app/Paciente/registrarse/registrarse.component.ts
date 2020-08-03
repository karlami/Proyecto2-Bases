import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/Modelos/paciente.model';
import { Patologia } from 'src/app/Modelos/patologia.model';
import { Pacientep } from 'src/app/Modelos/pacientep.model';
import { PacienteManagementService } from 'src/app/Servicios/paciente-management.service';
import { PatologiaManagementService } from 'src/app/Servicios/patologia-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-registrarse',
  templateUrl: './registrarse.component.html',
  styleUrls: ['./registrarse.component.css']
})
export class RegistrarseComponent implements OnInit {

  pacienteList: Paciente[];
  pacienteForm: NgForm;
  patologiaForm: NgForm;
  updateForm: NgForm;
  submitted = false;
  pacientee: Pacientep;
  patologiaa: Patologia;
  closeResult = '';

  constructor(public service: PacienteManagementService,public servicepat: PatologiaManagementService, 
    private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit(): void {
    // this.service.getPacientes();
    this.generateForm();
    this.generateFormPat();
  }


  generateForm(pacienteForm?: NgForm) {
    if (pacienteForm != null) {
      pacienteForm.reset();
    }
    this.pacientee = {
        nombre: '',
        primerapellido: '',
        segundoapellido: '',
        cedula: 1,
        telefono: 1,
        iddireccion: 1,
        fechanacimiento: new Date('Ene 01 2020'),
        contrasena: ''
    };

  }


  generateFormPat(patologiaForm?: NgForm) {
    if (patologiaForm != null) {
      patologiaForm.reset();
    }
    this.patologiaa = {
        idpaciente: 1,
        idpatologia: 1,
        tratamiento: ''
    };

  }



  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
    this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
    this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
    }
  
    private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
    return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
    return 'by clicking on a backdrop';
    } else {
    return `with: ${reason}`;
    }
    }

  onSubmit(pacienteForm: NgForm) {
    console.log('Ingresado');
    // console.log(this.service.postPacientes(this.pacientee));
    // this.service.postPacientes(this.pacientee);
    this.generateForm();
    console.log(this.pacientee.cedula);
  }


  onInsertPat(patologiaForm: NgForm) {
    console.log('Ingresado');
    // console.log(this.servicepat.postPatologias(this.patologiaa));
    // this.servicepat.postPatologias(this.patologiaa);
    this.generateForm();
    console.log(this.pacientee.cedula);
  }


}
