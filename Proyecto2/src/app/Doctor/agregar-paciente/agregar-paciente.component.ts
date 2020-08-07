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
  selector: 'app-agregar-paciente',
  templateUrl: './agregar-paciente.component.html',
  styleUrls: ['./agregar-paciente.component.css']
})
export class AgregarPacienteComponent implements OnInit {

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
        cedula: undefined,
        telefono: undefined,
        iddireccion: undefined,
        fechanacimiento: undefined,
        contrasena: ''
    };

  }


  generateFormPat(patologiaForm?: NgForm) {
    if (patologiaForm != null) {
      patologiaForm.reset();
    }
    this.patologiaa = {
        idpaciente: undefined,
        idpatologia: undefined,
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
    console.log(this.pacientee);
    console.log(this.service.postPaciente(this.pacientee));
    this.generateForm();
    //window.location.reload();
  }


  onInsertPat(patologiaForm: NgForm) {
    console.log('Ingresado');
    // console.log(this.servicepat.postPatologias(this.patologiaa));
    // this.servicepat.postPatologias(this.patologiaa);
    this.generateForm();
    console.log(this.pacientee.cedula);
  }


}
