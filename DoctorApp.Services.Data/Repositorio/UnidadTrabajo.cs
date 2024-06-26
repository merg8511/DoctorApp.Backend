﻿using DoctorApp.Services.Data.Interfaces.IRepositorio;

namespace DoctorApp.Services.Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _context;
        public IEspecialidadRepositorio Especialidad { get; private set; }

        public UnidadTrabajo(ApplicationDbContext context)
        {
            _context = context;
            Especialidad = new EspecialidadRepositorio(_context);
        }

        public async Task Guardar()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
