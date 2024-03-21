
namespace agenda_api.src.Services.Calendario.Eventos.Calendario.Application.Requests;

public class AdicionarEventoRequest 
{
    public Guid Id { get; set; }
    public int Status { get; set; }
    public DateTime Data { get; set; }
    public string Horario { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
}