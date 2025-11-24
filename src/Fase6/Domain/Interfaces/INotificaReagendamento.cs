using Fase06.Domain;

namespace Fase06.Contracts;

public interface INotificaReagendamento
{
    string EnviarReagendamento(Agendamento ag);
}
