import { Component, OnInit } from '@angular/core';
import { Salon } from 'src/app/Modelos/salon.model';
import { Salonp } from 'src/app/Modelos/salonp.model';
import { SalonManagementService } from 'src/app/Servicios/salon-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { TipoMedicinaM } from 'src/app/Modelos/tipo-medicina-m.model';

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
  tipoList: TipoMedicinaM[] = [{id: 1, nombre: 'Mujeres'}, {id: 2, nombre: 'Hombres'}, {id: 3, nombre: 'Niños'}];
  tipoSeleccionado: number

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
  numerosalon: undefined,
  nombre: '',
  cantidadcama: undefined,
  idtiposalon: 1,
  numeropiso: undefined
  };

  }

  generateForm(updateForm?: NgForm) {
  if (updateForm != null) {
  updateForm.reset();
  }
  this.salonn = {
    nombre: '',
    cantidadcama: undefined,
    idtiposalon: undefined,
    numeropiso: undefined
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
  console.log(this.salonn);
  this.service.postSalon(this.salonn);
  this.generateFormU();
  this.generateForm();
  window.location.reload();
  }

  onUpdate(updateForm: NgForm) {
  console.log('Actualizado');
  console.log(this.salonU);
  this.service.putSalon(this.salonU);
  this.generateFormU();
  this.generateForm();
  window.location.reload();
  }

  onDelete(numero: number) {
  console.log('Deleted');
  console.log(numero);
  this.service.deleteSalon(numero);
  this.generateFormU();
  this.generateForm();
  
  window.location.reload();
  }

  selectId(salon: Salon) {
  this.salonU = salon;
  console.log(this.salonU);
  console.log(this.salonU.numerosalon);
  }

  obtenerTipo(variable: any){
    if(variable == 1){
      this.salonn.idtiposalon = 1;
      this.salonU.idtiposalon = 1;
    }else if(variable == 2){
      this.salonn.idtiposalon = 2;
      this.salonU.idtiposalon = 2;
    }else{
      this.salonn.idtiposalon = 3;
      this.salonU.idtiposalon = 3;
    }
  } 

}

