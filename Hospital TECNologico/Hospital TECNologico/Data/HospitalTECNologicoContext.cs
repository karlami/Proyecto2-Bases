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

        /*public HospitalTECNologicoContext()
            : base()
        {
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PersonaConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        public DbSet<Equipo> equipo { get; set; }
        public DbSet<Salon> salon { get; set; }
        public DbSet<Procedimiento> procedimiento { get; set; }
        public DbSet<Historial_Clinico> historial_clinico { get; set; }
        public DbSet<Paciente_Patologia> paciente_patologia { get; set; }
    }
}
