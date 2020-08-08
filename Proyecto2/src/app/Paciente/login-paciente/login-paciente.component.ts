import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/Modelos/login.model';
import { LoginManagementService } from 'src/app/Servicios/login-management.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-paciente',
  templateUrl: './login-paciente.component.html',
  styleUrls: ['./login-paciente.component.css']
})
export class LoginPacienteComponent implements OnInit {

  encuestaList: Login[];
  encuestaForm: NgForm;
  submitted = false;
  encuestaa: Login;
  closeResult = '';

  constructor(public service: LoginManagementService, private formBuilder: FormBuilder) { }

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
    // console.log(this.service.postEncuesta(this.encuestaa));
    // this.service.postLogin(this.encuestaa);
    this.generateForm();
  }

}
