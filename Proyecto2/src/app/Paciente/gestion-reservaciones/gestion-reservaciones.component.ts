import { Component, OnInit } from '@angular/core';
import { Reservacion } from 'src/app/Modelos/reservacion.model';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { ReservacionManagementService } from 'src/app/Servicios/reservacion-management.service';

@Component({
  selector: 'app-gestion-reservaciones',
  templateUrl: './gestion-reservaciones.component.html',
  styleUrls: ['./gestion-reservaciones.component.css']
})
export class GestionReservacionesComponent implements OnInit {
  PacienteActual:any;
  constructor(public service: ReservacionManagementService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.PacienteActual = localStorage.getItem("idPaciente");
    this.service.getReservacion(this.PacienteActual);
    console.log(this.service.reservacionList);
  }

}
