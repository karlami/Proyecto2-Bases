using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital_TECNologico.Models;
using Hospital_TECNologico.Models.Views;

namespace Hospital_TECNologico.Data
{
    public class HospitalTECNologicoContext : DbContext
    {
        public HospitalTECNologicoContext(DbContextOptions<HospitalTECNologicoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PersonaConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        //Tables
        public DbSet<Persona> persona { get; set; }
        public DbSet<Paciente> paciente { get; set; }
        public DbSet<Paciente_Patologia> paciente_patologia { get; set; }
        public DbSet<Reservacion> reservacion { get; set; }
        public DbSet<Reservacion_Procedimiento> reservacion_procedimiento { get; set; }
        public DbSet<Procedimiento> procedimiento { get; set; }
        public DbSet<Historial_Clinico> historial_clinico { get; set; }
        public DbSet<Salon> salon { get; set; }
        public DbSet<Equipo> equipo { get; set; }
        public DbSet<Cama> cama { get; set; }
        public DbSet<Empleado> empleado { get; set; }
        public DbSet<Direccion> direccion { get; set; }
        
        //Views
        public DbSet<vHistorial_Clinico> vhistorial_clinico { get; set; }
        public DbSet<vPaciente> vpaciente { get; set; }
        public DbSet<vReservacion_Procedimiento> vreservacion_procedimiento { get; set; }
        public DbSet<vSalon> vsalon { get; set; }
        public DbSet<vCama> vcama { get; set; }
        public DbSet<vEmpleado> vempleado { get; set; }
        public DbSet<vPaciente_Patologia> vpaciente_patologia { get; set; }
    }
}
