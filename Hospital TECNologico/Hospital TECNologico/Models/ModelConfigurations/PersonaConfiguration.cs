using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_TECNologico.Models.ModelConfigurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(prop => prop.cedula)
                .HasName("cedula");

            builder.Property(prop => prop.nombre)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.primerApellido)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.segundoApellido)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(prop => prop.telefono)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(prop => prop.fechaNacimiento)
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(prop => prop.idDireccion)
                .HasColumnType("INTEGER")
                .IsRequired();
        }
    }
}
