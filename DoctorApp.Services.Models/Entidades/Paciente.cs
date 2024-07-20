using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Models.Entidades
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0} debe contener un mínimo de {2} y máximo de {1} caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0} debe contener un mínimo de {2} y máximo de {1} caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} debe contener un mínimo de {2} y máximo de {1} caracteres")]
        public string Direccion { get; set; }

        [StringLength(40, MinimumLength = 1, ErrorMessage = "{0} debe contener un mínimo de {2} y máximo de {1} caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        public char Genero { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        [Display(Name = "Creado por")]
        public int? CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public UsuarioAplicacion CreadoPor { get; set; }

        [Display(Name = "Actualizado por")]
        public int? ActualizadoPorId { get; set; }

        [ForeignKey("ActualizadoPorId")]
        public UsuarioAplicacion ActualizadoPor { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }

    }
}
