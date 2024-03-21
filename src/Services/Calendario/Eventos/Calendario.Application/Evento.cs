using agenda_api.src.Shared;

namespace agenda_api.src.Services.Calendario.Eventos.Calendario.Application;

public class Evento
{
    public Guid Id { get; set; }
    public StatusEvento Status { get; set; }
    public DateTime Data { get; set; }
    public string Horario { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
}