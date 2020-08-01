import { Component, OnInit } from '@angular/core';
import { Salon } from 'src/app/Modelos/salon.model';
import { Salonp } from 'src/app/Modelos/salonp.model';
import { SalonManagementService } from 'src/app/Servicios/salon-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-gestion-salones',
  templateUrl: './gestion-salones.component.html',
  styleUrls: ['./gestion-salones.component.css']
})
export class GestionSalonesComponent implements OnInit {

  salonList: Salon[];
  salonForm: NgForm;
  updateForm: NgForm;
  submitted = false;
  salonn: Salonp;
  salonU: Salon;
  closeResult = '';

  constructor(public service: SalonManagementService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {
  this.service.getSalones();
  this.generateFormU();
  this.generateForm();
  }

  generateFormU(salonForm?: NgForm) {
  if (salonForm != null) {
    salonForm.reset();
  }
  this.salonU = {
  numero: 1,
  nombre: '',
  capacidadcamas: 1,
  tipomedicina: '',
  piso: 1
  };

  }

  generateForm(updateForm?: NgForm) {
  if (updateForm != null) {
  updateForm.reset();
  }
  this.salonn = {
    nombre: '',
    capacidadcamas: 1,
    tipomedicina: '',
    piso: 1
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

  onSubmit(salonForm: NgForm) {
  console.log('Ingresado');
  console.log(this.service.postSalones(this.salonn));
  this.service.postSalones(this.salonn);
  this.service.getSalones();
  this.generateFormU();
  this.generateForm();
  }

  onUpdate(updateForm: NgForm) {
  console.log('Actualizado');
  console.log(this.salonU);
  this.service.putSalones(this.salonU);
  this.service.getSalones();
  this.generateFormU();
  this.generateForm();
  }

  onDelete(numero: number) {
  console.log('Deleted');
  this.service.deleteSalones(numero);
  this.service.getSalones();
  this.generateFormU();
  this.generateForm();
  }

  selectId(salon: Salon) {
  this.salonU = salon;
  console.log(this.salonU);
  console.log(this.salonU.numero);
  }

}

