using Hospital_TECNologico.Models.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_TECNologico.Models
{
    public class HospitalTECNologicoContext : DbContext
    {
        public HospitalTECNologicoContext(DbContextOptions<HospitalTECNologicoContext> options) : base(options)
        {
            //this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonaConfiguration());
        }

        public DbSet<Persona> persona { get; set; }
    }
}
