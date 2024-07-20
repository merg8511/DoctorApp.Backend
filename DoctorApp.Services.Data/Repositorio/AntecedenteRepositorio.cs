using DoctorApp.Services.Data.Interfaces.IRepositorio;
using DoctorApp.Services.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Repositorio
{
    public class AntecedenteRepositorio : RepositorioGenerico<Antecedente>, IAntecedenteRepositorio
    {
        private readonly ApplicationDbContext _context;
        public AntecedenteRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Antecedente antecedente)
        {
            var antecedenteDb = _context.Antecedentes.FirstOrDefault(e => e.Id == antecedente.Id);

            if (antecedenteDb != null)
            {
                antecedenteDb.FechaActualizacion = DateTime.Now;
                antecedenteDb.Observacion = antecedente.Observacion;

                _context.SaveChanges();
            }
        }
    }
}
