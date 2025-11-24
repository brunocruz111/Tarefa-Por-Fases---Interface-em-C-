using Fase06.Domain;

namespace Fase06.Contracts;

public interface INotificaLembrete
{
    string EnviarLembrete(Agendamento ag);
}
