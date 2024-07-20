using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Models.Entidades
{
    public class Antecedente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        public Guid HistoriaClinicaId { get; set; }

        [ForeignKey("HistoriaClinicaId")]
        public HistoriaClinica HistoriaClinica { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "La {0} debe ser mínimo {2} máximo {1} caracteres")]
        public string Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }


    }
}
