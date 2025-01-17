import { Component, OnInit } from '@angular/core';
import { Equipo } from 'src/app/Modelos/equipo.model';
import { Equipop } from 'src/app/Modelos/equipop.model';
import { EquipoManagementService } from 'src/app/Servicios/equipo-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-gestion-equipo',
  templateUrl: './gestion-equipo.component.html',
  styleUrls: ['./gestion-equipo.component.css']
})
export class GestionEquipoComponent implements OnInit {
  equipoList: Equipo[];
  equipoForm: NgForm;
  updateForm: NgForm;
  submitted = false;
  equipoo: Equipop;
  equipoU: Equipo;
  closeResult = '';

  constructor(public service: EquipoManagementService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {
  this.service.getEquipos();
  this.generateFormU();
  this.generateForm();
  }

  // metodo para crear el formulario para el put
  generateFormU(equipoForm?: NgForm) {
  if (equipoForm != null) {
  equipoForm.reset();
  }
  this.equipoU = {
  idequipo: undefined,
  nombre: '',
  proveedor: '',
  cantidad: undefined
  };

  }

  // metodo para crear el formulario para el post
  generateForm(updateForm?: NgForm) {
  if (updateForm != null) {
  updateForm.reset();
  }
  this.equipoo = {
    nombre: '',
    proveedor: '',
    cantidad: undefined
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
  console.log(this.equipoo);
  this.service.postEquipo(this.equipoo);
  this.service.getEquipos();
  this.generateFormU();
  this.generateForm();
  window.location.reload();
  }

  // metodo para el put
  onUpdate(updateForm: NgForm) {
  console.log('Actualizado');
  console.log(this.equipoU);
  this.service.putEquipo(this.equipoU);
  this.generateFormU();
  this.generateForm();
  window.location.reload();
  }

  // metodo para seleccionar un unico equipo
  selectId(equipo: Equipo) {
  this.equipoU = equipo;
  console.log(this.equipoU);
  console.log(this.equipoU.idequipo);
  }

}
