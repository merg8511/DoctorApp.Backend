using DoctorApp.Services.Models.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Services.Data.Inicializador
{
    public class DbInicializador : IDbInicializador
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly RoleManager<RolAplicacion> _roleManager;

        public DbInicializador(ApplicationDbContext context, UserManager<UsuarioAplicacion> userManager,
            RoleManager<RolAplicacion> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Inicializar()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (_context.Roles.Any(r => r.Name == "Admin"))
            {
                return;
            }

            // Crear roles
            _roleManager.CreateAsync(new RolAplicacion { Name = "Admin" }).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new RolAplicacion { Name = "Agendador" }).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new RolAplicacion { Name = "Doctor" }).GetAwaiter().GetResult();

            // Crear usuario Admin
            var usuario = new UsuarioAplicacion
            {
                UserName = "administrador",
                Email = "administrador@doctorapp.com",
                Apellidos = "Rodriguez",
                Nombres = "Mario",
            };
            _userManager.CreateAsync(usuario, "Admin123@").GetAwaiter().GetResult();

            //Asignar rol Admin al usuario Admin
            UsuarioAplicacion usuarioAdmin = _context.UsuarioAplicacion
                .Where(u => u.UserName == "administrador")
                .FirstOrDefault();

            _userManager.AddToRoleAsync(usuarioAdmin, "Admin").GetAwaiter().GetResult();
        }
    }
}
