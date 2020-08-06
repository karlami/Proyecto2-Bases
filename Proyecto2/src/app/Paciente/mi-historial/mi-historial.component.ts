import { Component, OnInit } from '@angular/core';
import { Historial } from 'src/app/Modelos/historial.model';
import { HistorialManagementService } from 'src/app/Servicios/historial-management.service';

@Component({
  selector: 'app-mi-historial',
  templateUrl: './mi-historial.component.html',
  styleUrls: ['./mi-historial.component.css']
})
export class MiHistorialComponent implements OnInit {

  historialList: Historial[];

  constructor(public service: HistorialManagementService) { }

  ngOnInit(): void {
    // this.service.getHistorial();
  }

}
