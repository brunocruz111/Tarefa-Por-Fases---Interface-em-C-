using Fase06.Domain;

namespace Fase06.Domain.Interfaces;

public interface INotificaReagendamento
{
    string EnviarReagendamento(Agendamento ag);
}
