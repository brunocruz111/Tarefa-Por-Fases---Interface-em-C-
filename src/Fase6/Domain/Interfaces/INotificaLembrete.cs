using Fase06.Domain;

namespace Fase06.Domain.Interfaces;

public interface INotificaLembrete
{
    string EnviarLembrete(Agendamento ag);
}
