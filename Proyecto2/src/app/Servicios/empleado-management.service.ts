import { Injectable } from '@angular/core';
import {ConstanteService} from '../Servicios/constante.service';
import {  HttpClient, HttpParams } from '@angular/common/http';
import {  HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Empleado } from '../Modelos/empleado.model';
import { Empleadop } from '../Modelos/empleadop.model';
@Injectable({
  providedIn: 'root'
})
export class EmpleadoManagementService {

  empleadoList: Empleado[];
  empleado: Empleado;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postEmpleado(empleadoData: Empleadop) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idempleado: 0,
      nombre: empleadoData.nombre,
      primerapellido: empleadoData.primerapellido,
      segundoapellido: empleadoData.segundoapellido,
      cedula: empleadoData.cedula,
      telefono: empleadoData.telefono,
      iddireccion: empleadoData.iddireccion,
      fechanacimiento: empleadoData.fechanacimiento,
      fechaingreso: empleadoData.fechaingreso,
      idpuesto: empleadoData.idpuesto,
      contrasena: empleadoData.contrasena
    };
    console.log(body);
    this.http.post(this.constante.rutaURL + '/api/PostEmpleado', body, httpOptions).toPromise();

  }

  putEmpleado(empleadoData: Empleado) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idempleado: empleadoData.idempleado,
      nombre: empleadoData.nombre,
      primerapellido: empleadoData.primerapellido,
      segundoapellido: empleadoData.segundoapellido,
      cedula: empleadoData.cedula,
      telefono: empleadoData.telefono,
      iddireccion: empleadoData.iddireccion,
      fechanacimiento: empleadoData.fechanacimiento,
      fechaingreso: empleadoData.fechaingreso,
      idpuesto: empleadoData.idpuesto,
      constrasena: empleadoData.contrasena
    };
    this.http.put(this.constante.rutaURL + '/api/PutMedicamentos', body, httpOptions).toPromise();
  }

  getEmpleado(idEmpleado: number) {
    this.http.get(this.constante.rutaURL + '/api/GetMedicamento/' + idEmpleado ).
    toPromise().then(res => this.empleado = res as Empleado);
  }
  
  getEmpleados() {
    //tslint:disable-next-line: no-string-literal
    this.http.get(this.constante.rutaURL + '/api/GetMedicamentos').toPromise().then
    (res => this.empleadoList = res as Empleado[]);
  }  
  
}
