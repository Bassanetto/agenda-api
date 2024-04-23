using Evento.Application.Configurations;

namespace Agenda.Api.Configurations;

public static class DataBaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection? services, IConfiguration configuration)
    {
        var defaultConnection = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        
        services.ConfigureDataBaseEventos(defaultConnection);
    }

    public static void UseDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

        serviceScope.UseDataBaseEventos();
    }
}