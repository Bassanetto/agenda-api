using Calendario.Domain.Queries.Eventos;
using Microsoft.EntityFrameworkCore;

namespace Calendario.Infra.Data.Contexts;

public class EventosContext : DbContext
{
    public DbSet<EventoDTO> Eventos { get; set; } = null!;

    public EventosContext(DbContextOptions<EventosContext> options) : base(options) { }
}