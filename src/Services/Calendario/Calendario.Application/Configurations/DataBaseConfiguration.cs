using Calendario.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Calendario.Application.Configurations;

public static class DataBaseConfiguration
{
    public static void ConfigureDataBaseEventos(this IServiceCollection services, string defaultConnection)
    {
        services.AddDbContext<EventosContext>(options => options.UseSqlServer(defaultConnection));
    }

    public static void UseDataBaseEventos(this IServiceScope serviceScope)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<EventosContext>();
        context.Database.Migrate();
    }
}