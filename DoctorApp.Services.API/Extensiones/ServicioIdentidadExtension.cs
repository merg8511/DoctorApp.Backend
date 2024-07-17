using DoctorApp.Services.Data;
using DoctorApp.Services.Models.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DoctorApp.Services.API.Extensiones
{
    public static class ServicioIdentidadExtension
    {
        public static IServiceCollection AgregarServicioIdentidad(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<UsuarioAplicacion>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<RolAplicacion>()
                .AddRoleManager<RoleManager<RolAplicacion>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey
                         (Encoding.UTF8.GetBytes(config["TokenKey"])),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRol", policy => policy.RequireRole("Admin"));
                options.AddPolicy("AdminAgendadorRol", policy => policy.RequireRole("Admin", "Agendador"));
                options.AddPolicy("AdminDoctorRol", policy => policy.RequireRole("Admin", "Doctor"));
            });

            return services;
        }
    }
}
