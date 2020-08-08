import { Injectable } from '@angular/core';
import { ConstanteService } from '../Servicios/constante.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Patologia } from '../Modelos/patologia.model';

@Injectable({
  providedIn: 'root'
})
export class PatologiaManagementService {

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postPatologia(patologiaData: Patologia) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idpaciente: patologiaData.idpaciente,
      idpatologia: patologiaData.idpatologia,
      tratamiento: patologiaData.tratamiento
    };
    this.http.post(this.constante.rutaURL + '/api/PostPaciente_Patologia', body, httpOptions).toPromise();

  }
}
