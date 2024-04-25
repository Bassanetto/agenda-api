using System.Text.Json;
using Calendario.Domain.Queries.Eventos;
using Calendario.Domain.Queries.Eventos.Repository;
using Calendario.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Calendario.Infra.Data.Repositories.Queries;

public class EventoQueryRepository : IEventoQueryRepository
{
    private readonly EventosContext _context;

    public EventoQueryRepository(EventosContext context)
    {
        _context = context;
    }

    public async Task<List<EventoDB>> ObterTodos()
    {
        var entidades = new List<EventoDB>();

        var eventos = await _context.Eventos.Select(o => new EventoDTO
        {
            Id = o.Id,
            ClienteId = o.ClienteId,
            JsonEventos = o.JsonEventos
        }).ToListAsync();

        foreach (var evento in eventos)
        {
            var json = JsonSerializer.Deserialize<JsonEventos>(evento.JsonEventos);

            var entidade = new EventoDB
            {
                Id = evento.Id,
                ClienteId = evento.ClienteId,
                Nome = json.Nome,
                Codigos = json.Codigos
            };

            entidades.Add(entidade);
        }

        return entidades;
    }

    #region Métodos Privados/Auxiliares
    private static EventoDTO EventoParaDTO(EventoDB evento)
    {
        var json = JsonSerializer.Serialize(new JsonEventos
        {
            Nome = evento.Nome,
            Codigos = evento.Codigos
        });

        return new EventoDTO
        {
            Id = evento.Id,
            ClienteId = evento.ClienteId,
            JsonEventos = json
        };
    }
    #endregion
}