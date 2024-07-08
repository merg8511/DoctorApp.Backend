using DoctorApp.Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.BLL.Servicios.Interfaces
{
    public interface IMedicoServicio
    {
        Task<IEnumerable<MedicoDto>> ObtenerTodos();
        Task<MedicoDto> Agregar(MedicoDto modeloDto);
        Task Actualizar(MedicoDto modeloDto);

        Task Remover(int id);
    }
}
