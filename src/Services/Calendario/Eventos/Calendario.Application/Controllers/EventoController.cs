using agenda_api.src.Services.Calendario.Eventos.Calendario.Application.Requests;
using agenda_api.src.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.src.Services.Calendario.Eventos.Calendario.Application.Controllers;

[Authorize]
[ApiController]
[Route("eventos")]
public class EventoController : ControllerBase
{
    private readonly ILogger<EventoController> _logger;

    public EventoController(ILogger<EventoController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Adicionar
    /// </summary>
    /// <param name="request">Solicitação com base no modelo **AdicionarEventoRequest**</param>
    /// <returns>Identificador atualizado</returns>
    [HttpPost, Route("")]
    public ActionResult<Evento> Adicionar([FromBody] AdicionarEventoRequest request)
    {
        var evento = new Evento
        {
            Id = Guid.NewGuid(),
            Status = StatusEvento.EmAndamento,
            Data = request.Data,
            Horario = request.Horario,
            Titulo = request.Titulo,
            Descricao = request.Descricao
        };


        return evento;
    }
}