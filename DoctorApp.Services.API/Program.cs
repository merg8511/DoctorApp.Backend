using DoctorApp.Services.API.Extensiones;
using DoctorApp.Services.API.Middleware;
using DoctorApp.Services.Data.Inicializador;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AgregarServicioAplicacion(builder.Configuration);
builder.Services.AgregarServicioIdentidad(builder.Configuration);
builder.Services.AddScoped<IDbInicializador, DbInicializador>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errores/{0}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod());

app.UseAuthentication();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var dbInicializador = services.GetRequiredService<IDbInicializador>();
        dbInicializador.Inicializar();

    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }

}

app.MapControllers();

app.Run();
