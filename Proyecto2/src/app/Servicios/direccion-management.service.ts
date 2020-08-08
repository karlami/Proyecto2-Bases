import { Injectable } from '@angular/core';
import {ConstanteService} from '../Servicios/constante.service';
import {  HttpClient, HttpParams } from '@angular/common/http';
import {  HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Direccion } from '../Modelos/direccion.model';


@Injectable({
  providedIn: 'root'
})
export class DireccionManagementService {

  direccionList: Direccion[];
  direccion: Direccion;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  getDirecciones() {
    // tslint:disable-next-line: no-string-literal
    this.http.get(this.constante.rutaURL + '/api/GetDirecciones').toPromise().then
    (res => this.direccionList = res as Direccion[]);
  }
}
