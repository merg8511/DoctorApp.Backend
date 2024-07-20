using DoctorApp.Services.Data.Interfaces.IRepositorio;
using DoctorApp.Services.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Repositorio
{
    public class HistoriaClinicaRepositorio : RepositorioGenerico<HistoriaClinica>, IHistoriaClinicaRepositorio
    {
        private readonly ApplicationDbContext _context;
        public HistoriaClinicaRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(HistoriaClinica historiaClinica)
        {
            var historiaClinicaDb = _context.HistoriasClinicas.FirstOrDefault(e => e.Id == historiaClinica.Id);

            if (historiaClinicaDb != null)
            {
                historiaClinicaDb.FechaActualizacion = DateTime.Now;

                _context.SaveChanges();
            }
        }
    }
}
