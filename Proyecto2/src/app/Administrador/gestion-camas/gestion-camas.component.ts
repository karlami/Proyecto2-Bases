import { Component, OnInit } from '@angular/core';
import { Cama } from 'src/app/Modelos/cama.model';
import { Camap } from 'src/app/Modelos/camap.model';
import { CamaManagementService } from 'src/app/Servicios/cama-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { EquipoManagementService } from 'src/app/Servicios/equipo-management.service';
import { SalonManagementService } from 'src/app/Servicios/salon-management.service';


@Component({
  selector: 'app-gestion-camas',
  templateUrl: './gestion-camas.component.html',
  styleUrls: ['./gestion-camas.component.css']
})
export class GestionCamasComponent implements OnInit {

  camaList: Cama[];
  camaForm: NgForm;
  updateForm: NgForm;
  submitted = false;
  camaa: Camap;
  camaU: Cama;
  closeResult = '';

  constructor(private SalonService:SalonManagementService, private equipoService:EquipoManagementService, public service: CamaManagementService, private formBuilder: FormBuilder,
              private modalService: NgbModal) { }

  ngOnInit(): void {
    this.service.getCamas();
    this.SalonService.getSalones();
    this.equipoService.getEquipos();
    this.generateFormU();
    this.generateForm();
  }

  // metodo para generar el formulario para el put
  generateFormU(camaForm?: NgForm) {
    if (camaForm != null) {
      camaForm.reset();
    }
    this.camaU = {
        numerocama: undefined,
        idequipo: undefined,
        idsalon: undefined,
        uci: false
    };

  }

  // metodo para generar el formulario para el post
  generateForm(updateForm?: NgForm) {
    if (updateForm != null) {
      updateForm.reset();
    }
    this.camaa = {
        idequipo: undefined,
        idsalon: undefined,
        uci: false
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
  onSubmit(camaForm: NgForm) {
    this.camaa.idequipo = Number (this.camaa.idequipo);
    this.camaa.idsalon = Number (this.camaa.idsalon);
    this.service.postCama(this.camaa);
    console.log(this.camaa);
    this.generateFormU();
    this.generateForm();
    window.location.reload();
  }

  // metodo para el put
  onUpdate(updateForm: NgForm) {
    console.log('Actualizado');
    this.camaU.idequipo = Number (this.camaU.idequipo);
    this.camaU.idsalon = Number (this.camaU.idsalon);
    this.service.putCama(this.camaU);
    this.generateFormU();
    this.generateForm();
    window.location.reload();
  }

   // metodo para seleccionar una sola cama
  selectId(cama: Cama) {
    this.camaU = cama;
    console.log(this.camaU);
  }

}

