import { Injectable } from '@angular/core';
import { ConstanteService } from '../Servicios/constante.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Procedimiento } from '../Modelos/procedimiento.model';
import { Procedimientop } from '../Modelos/procedimientop.model';

@Injectable({
  providedIn: 'root'
})
export class ProcedimientoManagementService {
  procedimientoList: Procedimiento[];
  procedimiento: Procedimiento;

  constructor(private http: HttpClient, private constante: ConstanteService) { }

  postProcedimiento(procedimientoData: Procedimientop) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      nombre: procedimientoData.nombre,
      diasrecuperacion: procedimientoData.diasrecuperacion
    };
    this.http.post(this.constante.rutaURL + '/api/PostProcedimiento', body, httpOptions).toPromise();

  }

  putProcedimiento(procedimientoData: Procedimiento) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      idprocedimiento: procedimientoData.idprocedimiento,
      nombre: procedimientoData.nombre,
      diasrecuperacion: procedimientoData.diasrecuperacion,
    };
    this.http.put(this.constante.rutaURL + '/api/PutProcedimiento', body, httpOptions).toPromise();
  }

  getProcedimiento(idProcedimiento: number) {
    this.http.get(this.constante.rutaURL + '/api/GetProcedimiento/' + idProcedimiento ).
    toPromise().then(res => this.procedimiento = res as Procedimiento);
  }
  
  getProcedimientos() {
    //tslint:disable-next-line: no-string-literal
    this.http.get(this.constante.rutaURL + '/api/GetProcedimientos').toPromise().then
    (res => this.procedimientoList = res as Procedimiento[]);
  }

}
