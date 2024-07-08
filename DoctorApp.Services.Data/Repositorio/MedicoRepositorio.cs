using DoctorApp.Services.Data.Interfaces.IRepositorio;
using DoctorApp.Services.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Repositorio
{
    public class MedicoRepositorio : RepositorioGenerico<Medico>, IMedicoRepositorio
    {
        private readonly ApplicationDbContext _context;
        public MedicoRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Medico medico)
        {
            var medicoDb = _context.Medicos.FirstOrDefault(e => e.Id == medico.Id);

            if (medicoDb != null)
            {
                medicoDb.Apellidos = medico.Apellidos;
                medicoDb.Nombres = medico.Nombres;
                medicoDb.Direccion = medico.Direccion;
                medicoDb.Estado = medico.Estado;
                medicoDb.FechaActualizacion = DateTime.Now;
                medicoDb.Telefono = medico.Telefono;
                medicoDb.Genero = medico.Genero;
                medicoDb.EspecialidadId = medicoDb.EspecialidadId;
                medicoDb.Direccion = medicoDb.Direccion;

                _context.SaveChanges();
            }
        }
    }
}
