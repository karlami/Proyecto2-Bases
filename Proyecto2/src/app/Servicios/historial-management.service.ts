import { Injectable } from '@angular/core';
import { ConstanteService } from '../Servicios/constante.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Historial } from '../Modelos/historial.model';
import { Historialp } from '../Modelos/historialp.model';

@Injectable({
  providedIn: 'root'
})
export class HistorialManagementService {
  historialList: Historial[];
  historial: Historial;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postHistorial(historialData: Historialp) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      cedula: historialData.cedula,
      idprocedimiento: historialData.idprocedimiento,
      fechaIngreso: historialData.fechaIngreso,
      tratamiento: historialData.tratamiento
    };
    this.http.post(this.constante.rutaURL + '/api/PostMedicamentos', body, httpOptions).toPromise();

  }
  putHistorial(historialData: Historial) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idHistorial: historialData.idHistorial,
      cedula: historialData.cedula,
      idprocedimiento: historialData.idprocedimiento,
      fechaIngreso: historialData.fechaIngreso,
      tratamiento: historialData.tratamiento
    };
    this.http.put(this.constante.rutaURL + '/api/PutMedicamentos', body, httpOptions).toPromise();
  }

  getHistorial(idPaciente: number) {
    this.http.get(this.constante.rutaURL + '/api/GetMedicamento/' + idPaciente ).
    toPromise().then(res => this.historialList = res as Historial[]);
  }
  
}
