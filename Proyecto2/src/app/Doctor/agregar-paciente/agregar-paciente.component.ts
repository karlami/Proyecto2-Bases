import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/Modelos/paciente.model';
import { Patologia } from 'src/app/Modelos/patologia.model';
import { Pacientep } from 'src/app/Modelos/pacientep.model';
import { PacienteManagementService } from 'src/app/Servicios/paciente-management.service';
import { PatologiaManagementService } from 'src/app/Servicios/patologia-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { DireccionManagementService } from 'src/app/Servicios/direccion-management.service';

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
  idPaciente:number;
  pacienteActual: any;

  constructor(private direccionService: DireccionManagementService, public service: PacienteManagementService,public servicepat: PatologiaManagementService, 
    private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.direccionService.getDirecciones();
    this.generateForm();
    this.generateFormPat();
  }

  // metodo para generar el formulario del put
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

  // metodo para generar el formulario del post
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

  // metodo para insertar paciente
  onSubmit(pacienteForm: NgForm) {
    this.pacientee.iddireccion = Number (this.pacientee.iddireccion);
    this.service.postPaciente(this.pacientee);
    console.log(this.pacientee);
    this.generateForm();
  }

  // metodo para insertar patologias
  onInsertPat(patologiaForm: NgForm) {
    console.log(this.patologiaa);
    this.servicepat.postPatologia(this.patologiaa);
    this.generateForm();
  }


}
