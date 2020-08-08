import { Component, OnInit } from '@angular/core';
import { Historial } from 'src/app/Modelos/historial.model';
import { HistorialManagementService } from 'src/app/Servicios/historial-management.service';
import { ViewPaciente } from 'src/app/Modelos/view-paciente.model'
@Component({
  selector: 'app-mi-historial',
  templateUrl: './mi-historial.component.html',
  styleUrls: ['./mi-historial.component.css']
})
export class MiHistorialComponent implements OnInit {
  PacienteActual:any;
  historialList: Historial[];

  constructor(public service: HistorialManagementService) { }

  ngOnInit(): void {
    this.PacienteActual = localStorage.getItem("idPaciente");
    console.log(this.PacienteActual);
    this.service.getHistorial(this.PacienteActual);
  }

}
