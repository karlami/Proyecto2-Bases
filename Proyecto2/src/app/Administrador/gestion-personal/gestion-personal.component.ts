import { Component, OnInit } from '@angular/core';
import { Empleado } from 'src/app/Modelos/empleado.model';
import { Empleadop } from 'src/app/Modelos/empleadop.model';
import { EmpleadoManagementService } from 'src/app/Servicios/empleado-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-gestion-personal',
  templateUrl: './gestion-personal.component.html',
  styleUrls: ['./gestion-personal.component.css']
})
export class GestionPersonalComponent implements OnInit {

  empleadoList: Empleado[];
  empleadoForm: NgForm;
  updateForm: NgForm;
  submitted = false;
  empleadoo: Empleadop;
  empleadoU: Empleado;
  closeResult = '';

  constructor(public service: EmpleadoManagementService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {
  // this.service.getEmpleados();
  this.generateFormU();
  this.generateForm();
  }

  generateFormU(empleadoForm?: NgForm) {
  if (empleadoForm != null) {
  empleadoForm.reset();
  }
  this.empleadoU = {
    idempleado: 1,
    nombre: '',
    primerapellido: '',
    segundoapellido: '',
    cedula: 1,
    telefono: 1,
    iddireccion: '',
    fechanacimiento: new Date('Ene 01 2020'),
    fechaingreso: new Date('Ene 01 2020'),
    idpuesto: '',
    contrasena: ''
  };

  }

  generateForm(updateForm?: NgForm) {
  if (updateForm != null) {
  updateForm.reset();
  }
  this.empleadoo = {
    nombre: '',
    primerapellido: '',
    segundoapellido: '',
    cedula: 1,
    telefono: 1,
    iddireccion: '',
    fechanacimiento: new Date('Ene 01 2020'),
    fechaingreso: new Date('Ene 01 2020'),
    idpuesto: '',
    contrasena: ''
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

  onSubmit(empeadoForm: NgForm) {
  console.log('Ingresado');
  // console.log(this.service.postEmpleados(this.empleadoo));
  // this.service.postEmpleados(this.empleadoo);
  // this.service.getEmpleados();
  this.generateFormU();
  this.generateForm();
  }

  onUpdate(updateForm: NgForm) {
  console.log('Actualizado');
  console.log(this.empleadoU);
  // this.service.putEmpleados(this.empleadoU);
  // this.service.getEmpleados();
  this.generateFormU();
  this.generateForm();
  }

  onDelete(idequipo: number) {
  console.log('Deleted');
  // this.service.deleteEmpleados(idempleado);
  // this.service.getEmpleados();
  this.generateFormU();
  this.generateForm();
  }

  selectId(empleado: Empleado) {
  this.empleadoU = empleado;
  console.log(this.empleadoU);
  console.log(this.empleadoU.idempleado);
  }

}

