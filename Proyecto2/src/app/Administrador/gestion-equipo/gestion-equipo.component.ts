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

  generateFormU(equipoForm?: NgForm) {
  if (equipoForm != null) {
  equipoForm.reset();
  }
  this.equipoU = {
  idequipo: 1,
  nombre: '',
  proveedor: '',
  cantidadequipo: 1
  };

  }

  generateForm(updateForm?: NgForm) {
  if (updateForm != null) {
  updateForm.reset();
  }
  this.equipoo = {
    nombre: '',
    proveedor: '',
    cantidadequipo: 1
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

  onSubmit(equipoForm: NgForm) {
  console.log('Ingresado');
  console.log(this.service.postEquipos(this.equipoo));
  this.service.postEquipos(this.equipoo);
  this.service.getEquipos();
  this.generateFormU();
  this.generateForm();
  }

  onUpdate(updateForm: NgForm) {
  console.log('Actualizado');
  console.log(this.equipoU);
  this.service.putEquipos(this.equipoU);
  this.service.getEquipos();
  this.generateFormU();
  this.generateForm();
  }

  onDelete(idequipo: number) {
  console.log('Deleted');
  this.service.deleteEquipos(idequipo);
  this.service.getEquipos();
  this.generateFormU();
  this.generateForm();
  }

  selectId(equipo: Equipo) {
  this.equipoU = equipo;
  console.log(this.equipoU);
  console.log(this.equipoU.idequipo);
  }

}
