namespace Evento.Domain.Queries.Eventos.Repository;

public interface IEventoQueryRepository
{
    Task<List<EventoDB>> ObterTodos();
}