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

        public HospitalTECNologicoContext()
            : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonaConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        public DbSet<Persona> persona { get; set; }
        public DbSet<Provincia> provincia { get; set; }
        public DbSet<Canton> canton { get; set; }
        public DbSet<Equipo> equipo { get; set; }
        public DbSet<Hospital_TECNologico.Models.Procedimiento> Procedimiento { get; set; }
    }
}
