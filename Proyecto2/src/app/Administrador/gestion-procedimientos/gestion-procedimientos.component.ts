import { Component, OnInit } from '@angular/core';
import { Procedimiento } from 'src/app/Modelos/procedimiento.model';
import { Procedimientop } from 'src/app/Modelos/procedimientop.model';
import { ProcedimientoManagementService } from 'src/app/Servicios/procedimiento-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-gestion-procedimientos',
  templateUrl: './gestion-procedimientos.component.html',
  styleUrls: ['./gestion-procedimientos.component.css']
})
export class GestionProcedimientosComponent implements OnInit {

  procedimientoList: Procedimiento[];
  procedimientoForm: NgForm;
  updateForm: NgForm;
  submitted = false;
  procedimientoo: Procedimientop;
  procedimientoU: Procedimiento;
  closeResult = '';

  constructor(public service: ProcedimientoManagementService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {
  this.service.getProcedimientos();
  this.generateFormU();
  this.generateForm();
  }

  // metodo para crear el formulario para el put
  generateFormU(procedimientoForm?: NgForm) {
  if (procedimientoForm != null) {
    procedimientoForm.reset();
  }
  this.procedimientoU = {
  idprocedimiento: undefined,
  nombre: '',
  diasrecuperacion: undefined
  };

  }

  // metodo para crear el formulario para el post
  generateForm(updateForm?: NgForm) {
  if (updateForm != null) {
  updateForm.reset();
  }
  this.procedimientoo = {
    nombre: '',
  diasrecuperacion: undefined
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

  // metodo para el post
  onSubmit(equipoForm: NgForm) {
  console.log('Ingresado');
  this.service.postProcedimiento(this.procedimientoo);
  this.generateFormU();
  this.generateForm();
  window.location.reload();
  }

  // metodo para el put
  onUpdate(updateForm: NgForm) {
  console.log('Actualizado');
  console.log(this.procedimientoU);
  this.service.putProcedimiento(this.procedimientoU);
  this.generateFormU();
  this.generateForm();
  }

  // metodo para seleccionar un unico procedimiento
  selectId(procedimiento: Procedimiento) {
  this.procedimientoU = procedimiento;
  console.log(this.procedimientoU);
  console.log(this.procedimientoU.idprocedimiento);
  }

}

