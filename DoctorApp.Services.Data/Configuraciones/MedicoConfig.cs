﻿using DoctorApp.Services.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Configuraciones
{
    public class MedicoConfig : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Apellidos).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Nombres).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.Genero).IsRequired().HasColumnType("char").HasMaxLength(1);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.EspecialidadId).IsRequired();

            /* Relaciones */

            builder.HasOne(x => x.Especialidad).WithMany()
                .HasForeignKey(x => x.EspecialidadId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
