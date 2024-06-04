using DoctorApp.Services.Data.Interfaces.IRepositorio;
using DoctorApp.Services.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Repositorio
{
    public class EspecialidadRepositorio : RepositorioGenerico<Especialidad>, IEspecialidadRepositorio
    {
        private readonly ApplicationDbContext _context;
        public EspecialidadRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Especialidad especialidad)
        {
            var especialidadDb = _context.Especialidades.FirstOrDefault(e => e.Id == especialidad.Id);

            if (especialidad != null)
            {
                especialidadDb.NombreEspecialidad = especialidad.NombreEspecialidad;
                especialidadDb.Descripcion = especialidad.Descripcion;
                especialidadDb.Estado = especialidad.Estado;
                especialidadDb.FechaActualizacion = DateTime.Now;

                _context.SaveChanges();
            }
        }
    }
}
