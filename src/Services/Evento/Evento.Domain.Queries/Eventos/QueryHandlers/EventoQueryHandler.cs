using Evento.Domain.Queries.Eventos.Repository;

namespace Evento.Domain.Queries.Eventos.QueryHandlers;

public interface IEventoQueryHandler
{
    Task<List<EventoDB>> ObterTodos();
}

public class EventoQueryHandler : IEventoQueryHandler
{
    private readonly IEventoQueryRepository _queryRepository;

    public EventoQueryHandler(IEventoQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<List<EventoDB>> ObterTodos()
    {
        var evento = await _queryRepository.ObterTodos();

        return evento;
    }
}