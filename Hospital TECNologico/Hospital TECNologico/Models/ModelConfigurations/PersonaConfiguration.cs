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
            builder.HasKey(prop => prop.cedula);

            builder.Property(prop => prop.nombre)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(prop => prop.primerapellido)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(prop => prop.segundoapellido)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(prop => prop.telefono)
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(prop => prop.fechanacimiento)
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(prop => prop.contrasena)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(prop => prop.iddireccion)
                .HasColumnType("INTEGER")
                .IsRequired();
        }
    }
}
