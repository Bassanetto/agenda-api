
namespace Calendario.Domain.Commands.Eventos.Repository;

public interface IEventoRepository
{
    void Adicionar(Evento produto);
    void Atualizar(Evento produto);
    Evento GetBy(Guid id);
    bool ExistePorId(Guid id);
}