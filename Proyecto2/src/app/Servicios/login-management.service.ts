import { Injectable } from '@angular/core';
import { ConstanteService } from '../Servicios/constante.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Login } from '../Modelos/login.model';
import { Paciente } from '../Modelos/paciente.model';
import { Empleado } from '../Modelos/empleado.model';

@Injectable({
  providedIn: 'root'
})
export class LoginManagementService {
  PacienteLog:Paciente;
  EmpleadoLog:Empleado;

  constructor(private http: HttpClient, private constante: ConstanteService) { }
  
  getCredencialesPaciente(cedula: number) {
    this.http.get(this.constante.rutaURL + 'api/GetPacienteC/' + cedula ).
    toPromise().then(res => this.PacienteLog = res as Paciente);
  }

  getCredencialesEmpleado(cedula: number) {
    this.http.get(this.constante.rutaURL + 'api/GetEmpleadoC/' + cedula ).
    toPromise().then(res => this.EmpleadoLog = res as Empleado);
  }

}
