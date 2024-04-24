using Evento.Domain.Queries.Eventos;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infra.Data.Contexts;

public class EventosContext : DbContext
{
    public DbSet<EventoDTO> Eventos { get; set; } = null!;

    public EventosContext(DbContextOptions<EventosContext> options) : base(options) { }
}