namespace Calendario.Domain.Queries.Eventos;

public class EventoDB
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public string Nome { get; set; }
    public List<string> Codigos { get; set; }
}