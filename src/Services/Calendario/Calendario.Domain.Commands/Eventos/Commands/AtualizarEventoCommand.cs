namespace Calendario.Domain.Commands.Eventos.Commands;

public class AtualizarEventoCommand
{
    public Guid Id { get; }
    public string Nome { get; }
    public List<string> Codigos { get; }

    public AtualizarEventoCommand(Guid id, string nome, List<string> codigos)
    {
        Id = id;
        Nome = nome;
        Codigos = codigos;
    }
}