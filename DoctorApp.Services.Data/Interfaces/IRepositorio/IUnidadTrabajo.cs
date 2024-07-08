using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Interfaces.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IEspecialidadRepositorio Especialidad { get; }
        IMedicoRepositorio Medico { get; }
        Task Guardar();
    }
}
