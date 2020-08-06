import { Injectable } from '@angular/core';
import { ConstanteService } from '../Servicios/constante.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Equipo } from '../Modelos/equipo.model';
import { Equipop } from '../Modelos/equipop.model';

@Injectable({
  providedIn: 'root'
})
export class EquipoManagementService {

  equipoList: Equipo[];
  equipo: Equipo;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postEquipo(equipoData: Equipop) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      nombre: equipoData.nombre,
      proveedor: equipoData.proveedor,
      cantidadequipo: equipoData.cantidadequipo
    };
    this.http.post(this.constante.rutaURL + '/api/PostEquipo', body, httpOptions).toPromise();

  }

  putEquipo(equipoData: Equipo) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idequipo: equipoData.idequipo,
      nombre: equipoData.nombre,
      proveedor: equipoData.proveedor,
      cantidadequipo: equipoData.cantidadequipo
    };
    this.http.put(this.constante.rutaURL + '/api/PutEquipo', body, httpOptions).toPromise();
  }

  getEquipo(idEquipo: number) {
    this.http.get(this.constante.rutaURL + 'api/GetEquipo/' + idEquipo ).
    toPromise().then(res => this.equipo = res as Equipo);
  }
  
  getEquipos() {
    //tslint:disable-next-line: no-string-literal
    this.http.get(this.constante.rutaURL + '/api/GetEquipos').toPromise().then
    (res => this.equipoList = res as Equipo[]);
  }

  deleteEmpleado(idequipo: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.delete(this.constante.rutaURL + '/api/DeleteEquipo/' + idequipo ,
    httpOptions).toPromise();

  }

}
