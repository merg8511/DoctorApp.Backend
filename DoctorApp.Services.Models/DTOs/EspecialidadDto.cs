
using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Services.Models.DTOs
{
    public class EspecialidadDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "El nombre debe ser mínimo {2} máximo {1} caracteres")]
        public string NombreEspecialidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La descripción debe ser mínimo {2} máximo {1} caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Estado { get; set; }
    }
}
