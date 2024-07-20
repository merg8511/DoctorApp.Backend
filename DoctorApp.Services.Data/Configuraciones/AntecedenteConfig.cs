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
    public class AntecedenteConfig : IEntityTypeConfiguration<Antecedente>
    {
        public void Configure(EntityTypeBuilder<Antecedente> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HistoriaClinicaId).IsRequired();

            /*relaciones */
            builder.HasOne(x => x.HistoriaClinica)
                .WithMany()
                .HasForeignKey(x => x.HistoriaClinicaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
