﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Models.Entidades
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "El nombre debe ser mínimo {2} máximo {1} caracteres")]
        public string NombreEspecialidad { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La descripción debe ser mínimo {2} máximo {1} caracteres")]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
