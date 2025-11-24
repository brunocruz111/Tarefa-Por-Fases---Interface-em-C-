using Fase06.Domain;
using Fase06.Domain.Interfaces;

namespace Fase06.Services;

public sealed class AppNotifier :
    INotificaConfirmacao, INotificaLembrete
{
    public string EnviarConfirmacao(Agendamento ag) =>
        $"[APP] {ag.Nome}, seu {ag.Servico} foi confirmado para {ag.FormatadoPtBr()}.";

    public string EnviarLembrete(Agendamento ag) =>
        $"[APP] Lembrete: {ag.Servico} às {ag.FormatadoPtBr()} (chegue 5 min antes).";
}
