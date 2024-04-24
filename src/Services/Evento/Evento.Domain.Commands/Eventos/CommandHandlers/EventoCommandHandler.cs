using Evento.Domain.Commands.Eventos.Commands;
using Evento.Domain.Commands.Eventos.Repository;

namespace Evento.Domain.Commands.Eventos.CommandHandlers;

public interface IEventoCommandHandler
{
    Evento Adicionar(AdicionarEventoRequest request);
    void Atualizar(AtualizarEventoCommand request);
}

public class EventoCommandHandler : IEventoCommandHandler
{
    private readonly IEventoRepository _repository;

    public EventoCommandHandler(IEventoRepository repository)
    {
        _repository = repository;
    }

    public Evento Adicionar(AdicionarEventoRequest request)
    {
        var evento = Evento.Factory.Novo(Guid.NewGuid(), request.ClienteId, request.Nome, request.Codigos);

        _repository.Adicionar(evento);

        return evento;
    }

    public void Atualizar(AtualizarEventoCommand request)
    {
        if (!ExisteMesmoId(request.Id)) return;

        var evento = _repository.GetBy(request.Id);

        evento.AtualizarNome(request.Nome);
        evento.AtualizarCodigos(request.Codigos);

        _repository.Atualizar(evento);

        return;
    }

    #region Métodos Privados/Auxiliares
    private bool ExisteMesmoId(Guid id)
    {
        var existe = _repository.ExistePorId(id);
        if (existe) return true;

        return false;
    }
    #endregion
}