import { Injectable } from '@angular/core';
import {ConstanteService} from '../Servicios/constante.service';
import {  HttpClient, HttpParams } from '@angular/common/http';
import {  HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Cama } from '../Modelos/cama.model';
import { Camap } from '../Modelos/camap.model';

@Injectable({
  providedIn: 'root'
})
export class CamaManagementService {

  camaList: Cama[];
  cama: Cama;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postCama(camaData: Camap) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      numerocama: camaData.numerocama,
      idequipo: camaData.idequipo,
      idsalon: camaData.idsalon,
      uci: camaData.uci
    };
    this.http.post(this.constante.rutaURL + '/api/PostCama', body, httpOptions).toPromise();

  }
  putCama(camaData: Cama) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      numerocama: camaData.numerocama,
      idequipo: camaData.idequipo,
      idsalon: camaData.idsalon,
      uci: camaData.uci
    };
    this.http.put(this.constante.rutaURL + '/api/PutMedicamentos', body, httpOptions).toPromise();
  }

  deleteEmpleado(empleadoid: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.delete(this.constante.rutaURL + '/api/DeleteMedicamentos/' + empleadoid ,
    httpOptions).toPromise();

  }

  getCama(idCama: number) {
    this.http.get(this.constante.rutaURL + '/api/GetMedicamento/' + idCama ).
    toPromise().then(res => this.cama = res as Cama);
  }
  
  getCamas() {
    // tslint:disable-next-line: no-string-literal
    this.http.get(this.constante.rutaURL + '/api/GetMedicamentos').toPromise().then
    (res => this.camaList = res as Cama[]);
  }
  
}
