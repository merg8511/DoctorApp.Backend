using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Models.Entidades
{
    public class Medico
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

        [MaxLength(40)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        public char Genero { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        public int EspecialidadId { get; set; }

        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
