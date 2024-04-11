using Agenda.Api.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.ConfigureDatabase(builder.Configuration);

#region Mapeando interfaces Eventos
// services.AddTransient<IEventoRepository, EventoRepository>();
// services.AddTransient<IEventoQueryRepository, EventoQueryRepository>();
// services.AddTransient<IEventoCommandHandler, EventoCommandHandler>();
// services.AddTransient<IEventoQueryHandler, EventoQueryHandler>();
#endregion

services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("eventos", new OpenApiInfo
    {
        Title = "Eventos",
        Description = "Breve descrição dos endpoints desta controller.",
        Version = "eventos"
    });
});

var app = builder.Build();

app.UseCors("MyAllowedOrigins");

// app.UseDatabase();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/eventos/swagger.json", "eventos");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();