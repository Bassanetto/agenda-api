namespace Evento.Domain.Queries.Eventos;

public class EventoDTO
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public string JsonEventos { get; set; }
}

public class JsonEventos
{
    public string Nome { get; set; }
    public List<string> Codigos { get; set; }
}