namespace Evento.Domain.Commands.Eventos;

public class Evento
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public string Nome { get; set; }
    public List<string> Codigos { get; set; }

    public void AtualizarNome(string nome) => Nome = nome;
    public void AtualizarCodigos(List<string> codigos) => Codigos = codigos;

    public static class Factory
    {
        public static Evento Novo(Guid id, Guid clienteId, string nome, List<string> codigos)
        {
            var evento = new Evento
            {
                Id = id,
                ClienteId = clienteId,
                Nome = nome,
                Codigos = codigos
            };

            return evento;
        }
    }
}