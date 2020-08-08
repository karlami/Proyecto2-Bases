import { Injectable } from '@angular/core';
import { ConstanteService } from '../Servicios/constante.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Paciente } from '../Modelos/paciente.model';
import { Pacientep } from '../Modelos/pacientep.model';
import { ViewPaciente } from '../Modelos/view-paciente.model';

@Injectable({
  providedIn: 'root'
})
export class PacienteManagementService {

  paciente: Paciente;
  pacienteC: ViewPaciente;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postPaciente(pacienteData: Pacientep) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      cedula: pacienteData.cedula,
      nombre: pacienteData.nombre,
      primerapellido: pacienteData.primerapellido,
      segundoapellido: pacienteData.segundoapellido,
      telefono: pacienteData.telefono,
      fechanacimiento: pacienteData.fechanacimiento,
      contrasena: pacienteData.contrasena,
      iddireccion: pacienteData.iddireccion
    };
    this.http.post(this.constante.rutaURL + '/api/PostPaciente', body, httpOptions).toPromise();

  }
  getCredencialesPaciente(cedula: number) {
    this.http.get(this.constante.rutaURL + '/api/GetPacienteC/' + cedula ).
    toPromise().then(res => this.pacienteC[0] = res as ViewPaciente);
  }

  getPaciente(idPaciente: number) {
    this.http.get(this.constante.rutaURL + '/api/GetMedicamento/' + idPaciente ).
    toPromise().then(res => this.paciente = res as Paciente);
  }
}
