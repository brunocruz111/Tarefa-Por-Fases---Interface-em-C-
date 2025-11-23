using Fase06.Domain;

namespace Fase06.Contracts;

public interface INotificaConfirmacao
{
    string EnviarConfirmacao(Agendamento ag);
}
