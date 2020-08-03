import { Injectable } from '@angular/core';
import { ConstanteService } from '../Servicios/constante.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Reservacion } from '../Modelos/reservacion.model';
import { Reservacionp } from '../Modelos/reservacionp.model';

@Injectable({
  providedIn: 'root'
})
export class ReservacionManagementService {
  reservacionList: Reservacion[];
  reservacion: Reservacion;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postReservacion(reservacionData: Reservacionp) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idpaciente: reservacionData.idpaciente,
      fechaingreso: reservacionData.fechaingreso,
      idprocedimientos: reservacionData.idprocedimientos,
      fechasalida: reservacionData.fechasalida
    };
    this.http.post(this.constante.rutaURL + '/api/PostMedicamentos', body, httpOptions).toPromise();

  }

  putReservacion(reservacionData: Reservacion) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idreservacion: reservacionData.idreservacion,
      idpaciente: reservacionData.idpaciente,
      fechaingreso: reservacionData.fechaingreso,
      idprocedimientos: reservacionData.idprocedimientos,
      fechasalida: reservacionData.fechasalida
    };
    this.http.put(this.constante.rutaURL + '/api/PutMedicamentos', body, httpOptions).toPromise();
  }

  getReservacion(idReservacion: number) {
    this.http.get(this.constante.rutaURL + '/api/GetMedicamento/' + idReservacion ).
    toPromise().then(res => this.reservacion = res as Reservacion);
  }
  
}
