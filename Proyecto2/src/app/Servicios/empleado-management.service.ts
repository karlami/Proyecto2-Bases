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
  deleteEmpleado(idEmpleado: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.delete(this.constante.rutaURL + '/api/DeleteEmpleado/' + idEmpleado ,
    httpOptions).toPromise();

  }
  putEmpleado(empleadoData: Empleado) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idempleado: empleadoData.idempleado,
      cedula: empleadoData.cedula,
      nombre: empleadoData.nombre,
      primerapellido: empleadoData.primerapellido,
      segundoapellido: empleadoData.segundoapellido,
      telefono: empleadoData.telefono,
      fechanacimiento: empleadoData.fechanacimiento,
      contrasena: empleadoData.contrasena,
      iddireccion: empleadoData.iddireccion,
      fechaingreso: empleadoData.fechaingreso,
      idpuesto: empleadoData.idpuesto
    };
    this.http.put(this.constante.rutaURL + '/api/PutEmpleado', body, httpOptions).toPromise();
  }

  getEmpleado(idEmpleado: number) {
    this.http.get(this.constante.rutaURL + '/api/GetMedicamento/' + idEmpleado ).
    toPromise().then(res => this.empleado = res as Empleado);
  }
  
  getEmpleados() {
    //tslint:disable-next-line: no-string-literal
    this.http.get(this.constante.rutaURL + '/api/GetEmpleados').toPromise().then
    (res => this.empleadoList = res as Empleado[]);
  }  
  
}
