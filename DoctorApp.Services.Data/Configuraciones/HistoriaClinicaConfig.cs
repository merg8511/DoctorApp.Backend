using DoctorApp.Services.Models.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Configuraciones
{
    public class HistoriaClinicaConfig : IEntityTypeConfiguration<HistoriaClinica>
    {
        public void Configure(EntityTypeBuilder<HistoriaClinica> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.PacienteId).IsRequired();

            /*relaciones */
            builder.HasOne(x => x.Paciente)
                .WithOne(x => x.HistoriaClinica)
                .HasForeignKey<HistoriaClinica>(x => x.PacienteId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
