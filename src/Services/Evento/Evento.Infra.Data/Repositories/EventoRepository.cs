using System.Text.Json;
using Evento.Domain.Commands.Eventos.Repository;
using Evento.Domain.Queries.Eventos;
using Evento.Infra.Data.Contexts;

namespace Evento.Infra.Data.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventosContext _context;

    public EventoRepository(EventosContext context)
    {
        _context = context;
    }

    public void Adicionar(Evento evento)
    {
        var json = new JsonEventos
        {
            Nome = evento.Nome,
            Codigos = evento.Codigos
        };

        var entidade = new EventoDTO
        {
            Id = evento.Id,
            ClienteId = evento.ClienteId,
            JsonEventos = JsonSerializer.Serialize(json)
        };

        _context.Add(entidade);
        _context.SaveChanges();

        return;
    }

    public void Atualizar(Evento evento)
    {
        var entidade = _context.Eventos.Find(evento.Id);

        var json = new JsonEventos
        {
            Nome = evento.Nome,
            Codigos = evento.Codigos
        };

        entidade.JsonEventos = JsonSerializer.Serialize(json);

        _context.Update(entidade);
        _context.SaveChanges();

        return;
    }

    public Evento GetBy(Guid id)
    {
        var evento = _context.Eventos.Find(id);

        var json = JsonSerializer.Deserialize<JsonEventos>(evento.JsonEventos);

        var entidade = new Evento
        {
            Id = evento.Id,
            ClienteId = evento.ClienteId,
            Nome = json.Nome,
            Codigos = json.Codigos
        };

        return entidade;
    }

    public bool ExistePorId(Guid id)
    {
        var evento = _context.Eventos.Find(id);

        if (evento is not null) return true;

        return false;
    }
}