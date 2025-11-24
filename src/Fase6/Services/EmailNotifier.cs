using Fase06.Domain;
using Fase06.Domain.Interfaces;

namespace Fase06.Services;

public sealed class EmailNotifier :
    INotificaConfirmacao, INotificaReagendamento
{
    public string EnviarConfirmacao(Agendamento ag) =>
        $"[EMAIL] Confirmação — {ag.Nome}, {ag.Servico} em {ag.FormatadoPtBr()}.";

    public string EnviarReagendamento(Agendamento ag) =>
        $"[EMAIL] Reagendamento — {ag.Nome}, {ag.Servico} para {ag.FormatadoPtBr()}.";
}
