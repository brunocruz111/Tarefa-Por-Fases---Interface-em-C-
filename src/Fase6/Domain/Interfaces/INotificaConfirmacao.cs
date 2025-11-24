using Fase06.Domain;

namespace Fase06.Domain.Interfaces;

public interface INotificaConfirmacao
{
    string EnviarConfirmacao(Agendamento ag);
}
