using Microsoft.EntityFrameworkCore;
using Tennos_Prueba.Infraestructura.persistence.Context;
using Tennos_Prueba.Infraestructura.persistence;
using Tennos_Prueba.Extenciones;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddSwaggerExtension();
builder.Services.CORS();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configurar la solicitud HTTP
app.UseCors("AllowAll"); // Aplicar la política de CORS
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
