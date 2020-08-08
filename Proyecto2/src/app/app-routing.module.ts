import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


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
import { WelcomeLoginPacienteComponent } from './Miscellanious/welcome-login-paciente/welcome-login-paciente.component';



const routes: Routes = [
  { path: 'HospitalTECnologico/Paciente', pathMatch: 'prefix',
    children: [
      { path: 'Inicio', component: WelcomePacienteComponent},
      { path: 'Registrase', component: RegistrarseComponent},
      { path: 'MiHistorial', component: MiHistorialComponent},
      { path: 'GestionReservaciones', component: GestionReservacionesComponent},
      { path: 'Encuesta', component: EncuestaComponent},
      { path: '**', component: WelcomePacienteComponent}
    ]
},

{ path: 'HospitalTECnologico/Login', pathMatch: 'prefix',
    children: [
      { path: 'Inicio', component: WelcomeLoginPacienteComponent},
      { path: 'Registrase', component: RegistrarseComponent},
      { path: 'Ingresar', component: LoginPacienteComponent},
      { path: '**', component: WelcomeLoginPacienteComponent}
    ]
},

{ path: 'HospitalTECnologico/Administrador', pathMatch: 'prefix',
    children: [
      { path: 'Inicio', component: WelcomeAdminComponent},
      { path: 'GestionSalones', component: GestionSalonesComponent},
      { path: 'GestionCamas', component: GestionCamasComponent},
      { path: 'GestionProcedimientos', component: GestionProcedimientosComponent},
      { path: 'GestionEquipo', component: GestionEquipoComponent},
      { path: 'GestionPersonal', component: GestionPersonalComponent},
      { path: 'ReporteAreaMejora', component: ReporteAreaMejoraComponent},
      { path: '**', component: WelcomeAdminComponent}
    ]
},

{ path: 'HospitalTECnologico/Doctor', pathMatch: 'prefix',
    children: [
      { path: 'Inicio', component: WelcomeDoctorComponent},
      { path: 'AgregarPaciente', component: AgregarPacienteComponent},
      { path: 'Historial', component: HistorialComponent},
      { path: '**', component: WelcomeDoctorComponent}
    ]
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
