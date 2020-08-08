import { Component, OnInit } from '@angular/core';
import { Reservacion } from 'src/app/Modelos/reservacion.model';
import { Reservacionp } from 'src/app/Modelos/reservacionp.model';
import { ReservacionManagementService } from 'src/app/Servicios/reservacion-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';



@Component({
  selector: 'app-gestion-reservaciones',
  templateUrl: './gestion-reservaciones.component.html',
  styleUrls: ['./gestion-reservaciones.component.css']
})
export class GestionReservacionesComponent implements OnInit {

  reservacionList: Reservacion[];
  reservacionForm: NgForm;
  submitted = false;
  reservacionn: Reservacionp;
  reservacion: Reservacion;
  closeResult = '';
  PacienteActual:any;

  constructor( public service: ReservacionManagementService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.PacienteActual = localStorage.getItem("idPaciente");
    this.service.getReservacion(this.PacienteActual);
    console.log(this.service.reservacionList);
  }

  // metodo para generar el formulario para el put
  generateFormU(reservacionForm?: NgForm) {
    if (reservacionForm != null) {
      reservacionForm.reset();
    }
    this.reservacionn = {
      idpaciente : this.PacienteActual,
      fechaingreso : undefined

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
  onSubmit(reservacionForm: NgForm) {
    this.service.postReservacion(this.reservacionn);
    console.log(this.reservacionn);
    this.generateFormU();
    window.location.reload();
  }


}


