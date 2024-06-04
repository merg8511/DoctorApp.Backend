using DoctorApp.Services.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Interfaces.IRepositorio
{
    public interface IEspecialidadRepositorio : IRepositorioGenerico<Especialidad>
    {
        void Actualizar(Especialidad especialidad);
    }
}
