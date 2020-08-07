import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarPacienteComponent } from './Miscellanious/nav-bar-paciente/nav-bar-paciente.component';
import { NavBarDoctorComponent } from './Miscellanious/nav-bar-doctor/nav-bar-doctor.component';
import { NavBarAdminComponent } from './Miscellanious/nav-bar-admin/nav-bar-admin.component';
import { WelcomePacienteComponent } from './Miscellanious/welcome-paciente/welcome-paciente.component';
import { WelcomeDoctorComponent } from './Miscellanious/welcome-doctor/welcome-doctor.component';
import { WelcomeAdminComponent } from './Miscellanious/welcome-admin/welcome-admin.component';
import { GestionSalonesComponent } from './Administrador/gestion-salones/gestion-salones.component';
import { GestionEquipoComponent } from './Administrador/gestion-equipo/gestion-equipo.component';
import { GestionCamasComponent } from './Administrador/gestion-camas/gestion-camas.component';
import { GestionProcedimientosComponent } from './Administrador/gestion-procedimientos/gestion-procedimientos.component';
import { GestionPersonalComponent } from './Administrador/gestion-personal/gestion-personal.component';
import { ReporteAreaMejoraComponent } from './Administrador/reporte-area-mejora/reporte-area-mejora.component';
import { GestionReservacionesComponent } from './Paciente/gestion-reservaciones/gestion-reservaciones.component';
import { HistorialComponent } from './Doctor/historial/historial.component';
import { EncuestaComponent } from './Paciente/encuesta/encuesta.component';
import { AgregarPacienteComponent } from './Doctor/agregar-paciente/agregar-paciente.component';
import { RegistrarseComponent } from './Paciente/registrarse/registrarse.component';
import { MiHistorialComponent } from './Paciente/mi-historial/mi-historial.component';
import { LoginPacienteComponent } from './Paciente/login-paciente/login-paciente.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarPacienteComponent,
    NavBarDoctorComponent,
    NavBarAdminComponent,
    WelcomePacienteComponent,
    WelcomeDoctorComponent,
    WelcomeAdminComponent,
    GestionSalonesComponent,
    GestionEquipoComponent,
    GestionCamasComponent,
    GestionProcedimientosComponent,
    GestionPersonalComponent,
    ReporteAreaMejoraComponent,
    GestionReservacionesComponent,
    HistorialComponent,
    EncuestaComponent,
    AgregarPacienteComponent,
    RegistrarseComponent,
    MiHistorialComponent,
    LoginPacienteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
// nuevo
