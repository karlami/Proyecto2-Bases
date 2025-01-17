import { Injectable } from '@angular/core';
import {ConstanteService} from '../Servicios/constante.service';
import {  HttpClient, HttpParams } from '@angular/common/http';
import {  HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Salon } from '../Modelos/salon.model';
import { Salonp } from '../Modelos/salonp.model';

@Injectable({
  providedIn: 'root'
})
export class SalonManagementService {

  salonList: Salon[];
  salon: Salon;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postSalon(salonData: Salonp) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      nombre: salonData.nombre,
      cantidadcama: salonData.cantidadcama,
      idtiposalon: salonData.idtiposalon,
      numeropiso: salonData.numeropiso
    };
    this.http.post(this.constante.rutaURL + '/api/PostSalon', body, httpOptions).toPromise();

  }

  putSalon(salonData: Salon) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      numerosalon: salonData.numerosalon,
      nombre: salonData.nombre,
      cantidadcama: salonData.cantidadcama,
      idtiposalon: salonData.idtiposalon,
      numeropiso: salonData.numeropiso
    };
    this.http.put(this.constante.rutaURL + '/api/PutSalon', body, httpOptions).toPromise();
  }

  getSalon(idSalon: number) {
    this.http.get(this.constante.rutaURL + '/api/GetSalon/' + idSalon ).
    toPromise().then(res => this.salon = res as Salon);
  }
  
  getSalones() {
    //tslint:disable-next-line: no-string-literal
    this.http.get(this.constante.rutaURL + '/api/GetSalones').toPromise().then
    (res => this.salonList = res as Salon[]);
  }

  deleteSalon(idSalon: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.delete(this.constante.rutaURL + '/api/DeleteSalon/' + idSalon ,
    httpOptions).toPromise();

  }

}
