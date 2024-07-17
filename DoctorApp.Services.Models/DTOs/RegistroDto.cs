using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Models.DTOs
{
    public class RegistroDto
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "El password debe tener mínimo {1} y máximo {2} caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Rol { get; set; }
    }
}
