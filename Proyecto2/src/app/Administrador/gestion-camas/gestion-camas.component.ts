import { Component, OnInit } from '@angular/core';
import { Cama } from 'src/app/Modelos/cama.model';
import { Camap } from 'src/app/Modelos/camap.model';
import { CamaManagementService } from 'src/app/Servicios/cama-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';


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

  constructor(public service: CamaManagementService, private formBuilder: FormBuilder,
              private modalService: NgbModal) { }

  ngOnInit(): void {
    // this.service.getCamas();
    this.generateFormU();
    this.generateForm();
  }

  generateFormU(camaForm?: NgForm) {
    if (camaForm != null) {
      camaForm.reset();
    }
    this.camaU = {
        idcama: 1,
        numerocama: 1,
        equipomedico: '',
        idsalon: 1,
        uci: false
    };

  }

  generateForm(updateForm?: NgForm) {
    if (updateForm != null) {
      updateForm.reset();
    }
    this.camaa = {
        numerocama: 1,
        equipomedico: '',
        idsalon: 1,
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

  onSubmit(camaForm: NgForm) {
    console.log('Ingresado');
    // console.log(this.service.postCamas(this.camaa));
    // this.service.postCamas(this.camaa);
    // this.service.getCamas();
    this.generateFormU();
    this.generateForm();
  }


  onUpdate(updateForm: NgForm) {
    console.log('Actualizado');
    console.log(this.camaU);
    // this.service.putCamas(this.camaU);
    // this.service.getCamas();
    this.generateFormU();
    this.generateForm();
  }

  onDelete(idcama: number) {
    console.log('Deleted');
    // this.service.deleteCamas(idcama);
    // this.service.getCamas();
    this.generateFormU();
    this.generateForm();
   }

  selectId(cama: Cama) {
    this.camaU = cama;
    console.log(this.camaU);
    console.log(this.camaU.idcama);
  }

}

