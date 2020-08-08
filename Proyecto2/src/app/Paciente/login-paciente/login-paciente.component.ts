import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/Modelos/login.model';
import { ViewPaciente } from 'src/app/Modelos/view-paciente.model';
import { LoginManagementService } from 'src/app/Servicios/login-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login-paciente',
  templateUrl: './login-paciente.component.html',
  styleUrls: ['./login-paciente.component.css']
})
export class LoginPacienteComponent implements OnInit {

  loginList: Login[];
  loginForm: NgForm;
  submitted = false;
  loginn: Login;
  closeResult = '';
  PacienteLog:ViewPaciente;
  contrasena:string;

  constructor(private toastr: ToastrService, public service: LoginManagementService, private formBuilder: FormBuilder, private _router: Router) { }

  ngOnInit(): void {
    this.generateForm();
  }

  generateForm(loginForm?: NgForm) {
    if (loginForm != null) {
      loginForm.reset();
    }
    this.loginn = {
        cedula: undefined,
        contrasena: ''
    };

  }

  onSubmit(loginForm: NgForm) {
    console.log('Ingresado');
    this.service.getCredencialesPaciente(this.loginn.cedula);
    console.log(this.service.PacienteLog);
    this.comprobarLogin();
  }
  comprobarLogin(){
    if(this.service.PacienteLog[0] != undefined){
      if(this.service.PacienteLog[0].contrasena == this.loginn.contrasena){
        localStorage.setItem('idPaciente', this.service.PacienteLog[0].idpaciente);
        this._router.navigateByUrl('/HospitalTECnologico/Paciente');
      }else{
        this.toastr.error('Error', 'La información ingresada no es válida.');
      }
    }else{
      this.toastr.error('Error', 'La información ingresada no es válida.');
    }

  }
}
