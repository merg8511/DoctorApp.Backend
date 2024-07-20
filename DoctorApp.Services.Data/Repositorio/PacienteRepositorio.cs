using DoctorApp.Services.Data.Interfaces.IRepositorio;
using DoctorApp.Services.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Repositorio
{
    public class PacienteRepositorio : RepositorioGenerico<Paciente>, IPacienteRepositorio
    {
        private readonly ApplicationDbContext _context;
        public PacienteRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Paciente paciente)
        {
            var pacienteDb = _context.Pacientes.FirstOrDefault(e => e.Id == paciente.Id);

            if (pacienteDb != null)
            {
                pacienteDb.Apellidos = paciente.Apellidos;
                pacienteDb.Nombres = paciente.Nombres;
                pacienteDb.Direccion = paciente.Direccion;
                pacienteDb.Estado = paciente.Estado;
                pacienteDb.FechaActualizacion = DateTime.Now;
                pacienteDb.Telefono = paciente.Telefono;
                pacienteDb.Genero = paciente.Genero;

                _context.SaveChanges();
            }
        }
    }
}
