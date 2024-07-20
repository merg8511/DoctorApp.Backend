using DoctorApp.Services.Data.Interfaces.IRepositorio;

namespace DoctorApp.Services.Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _context;
        public IEspecialidadRepositorio Especialidad { get; private set; }
        public IMedicoRepositorio Medico { get; private set; }
        public IPacienteRepositorio Paciente { get; private set; }
        public IHistoriaClinicaRepositorio HistoriaClinica { get; private set; }
        public IAntecedenteRepositorio Antecedente { get; private set; }

        public UnidadTrabajo(ApplicationDbContext context)
        {
            _context = context;
            Especialidad = new EspecialidadRepositorio(_context);
            Medico = new MedicoRepositorio(_context);
            Paciente = new PacienteRepositorio(_context);
            HistoriaClinica = new HistoriaClinicaRepositorio(_context);
            Antecedente = new AntecedenteRepositorio(_context);
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
