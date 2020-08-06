using Hospital_TECNologico.Models.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital_TECNologico.Models;

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

        public DbSet<Persona> persona { get; set; }
        public DbSet<Paciente> paciente { get; set; }
        public DbSet<Paciente_Patologia> paciente_patologia { get; set; }
        //Patologia?
        //Reservacion
        public DbSet<Reservacion_Procedimiento> reservacion_procedimiento { get; set; }
        public DbSet<Procedimiento> procedimiento { get; set; }
        public DbSet<Historial_Clinico> historial_clinico { get; set; }
        public DbSet<Salon> salon { get; set; }
        public DbSet<Equipo> equipo { get; set; }
        public DbSet<Cama> cama { get; set; }
        public DbSet<Empleado> empleado { get; set; }
        
        
        
        
        
    }
}
