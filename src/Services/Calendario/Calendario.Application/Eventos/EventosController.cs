
using Calendario.Domain.Commands.Eventos.CommandHandlers;
using Calendario.Domain.Commands.Eventos.Commands;
using Calendario.Domain.Queries.Eventos;
using Calendario.Domain.Queries.Eventos.QueryHandlers;
using Calendario.Infra.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calendario.Application.Eventos
{
    /// <summary>
    /// Eventos
    /// </summary>
    [Route("api/eventos")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "eventos")]
    public class EventosController : ControllerBase
    {
        /// <summary>
        /// Eventos
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mediatorQuery"></param>
        /// <param name="notification"></param>
        private readonly EventosContext _context;
        private readonly IEventoCommandHandler _commandHandler;
        private readonly IEventoQueryHandler _queryHandler;

        public EventosController(EventosContext context, IEventoCommandHandler commandHandler, IEventoQueryHandler queryHandler)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        /// <summary>
        /// Obter Eventos
        /// </summary>
        /// <returns>Objeto correspondente</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDB>>> GetEventos()
        {
            return await _queryHandler.ObterTodos();
        }

        /// <summary>
        /// Adicionar Evento
        /// </summary>
        /// <returns>Objeto correspondente</returns>
        [HttpPost]
        public IActionResult PostEvento(AdicionarEventoRequest request)
        {
            var evento = _commandHandler.Adicionar(request);

            return CreatedAtAction(nameof(PostEvento), evento);
        }

        /// <summary>
        /// Atualizar Evento
        /// </summary>
        /// <returns>Objeto correspondente</returns>
        [HttpPut("{id:guid}")]
        public IActionResult PutEvento(Guid id, AtualizarEventoCommand request)
        {
            var evento = _context.Eventos.Find(id);
            if (evento is null)
                return NotFound();

            try
            {
                _commandHandler.Atualizar(request);
            }
            catch (DbUpdateConcurrencyException) when (!EventosExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Excluir Evento
        /// </summary>
        /// <returns>Objeto correspondente</returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEvento(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento is null)
                return NotFound();

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #region Métodos Privados/Auxiliares

        private bool EventosExists(Guid id)
        {
            return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion
    }
}