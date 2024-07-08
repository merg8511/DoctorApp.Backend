using DoctorApp.Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.BLL.Servicios.Interfaces
{
    public interface IEspecialidadServicio
    {
        Task<IEnumerable<EspecialidadDto>> ObtenerTodos();
        Task<EspecialidadDto> Agregar(EspecialidadDto modeloDto);
        Task Actualizar(EspecialidadDto modeloDto);
        Task Remover(int id);
        Task<IEnumerable<EspecialidadDto>> ObtenerActivos();
    }
}
