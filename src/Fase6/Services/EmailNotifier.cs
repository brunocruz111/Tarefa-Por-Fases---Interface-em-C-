using Fase06.Contracts;
using Fase06.Domain;

namespace Fase06.Channels;

public sealed class EmailNotifier :
    INotificaConfirmacao, INotificaReagendamento
{
    public string EnviarConfirmacao(Agendamento ag) =>
        $"[EMAIL] Confirmação — {ag.Nome}, {ag.Servico} em {ag.FormatadoPtBr()}.";

    public string EnviarReagendamento(Agendamento ag) =>
        $"[EMAIL] Reagendamento — {ag.Nome}, {ag.Servico} para {ag.FormatadoPtBr()}.";
}
