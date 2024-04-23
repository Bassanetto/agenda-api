namespace Evento.Domain.Commands.Eventos.Commands;

public class AdicionarEventoRequest
{
    public Guid ClienteId { get; }
    public string Nome { get; }
    public List<string> Codigos { get; }

    public AdicionarEventoRequest(Guid clienteId, string nome, List<string> codigos)
    {
        ClienteId = clienteId;
        Nome = nome;
        Codigos = codigos;
    }
}