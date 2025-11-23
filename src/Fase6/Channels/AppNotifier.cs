using Fase06.Contracts;
using Fase06.Domain;

namespace Fase06.Channels;

public sealed class AppNotifier :
    INotificaConfirmacao, INotificaLembrete
{
    public string EnviarConfirmacao(Agendamento ag) =>
        $"[APP] {ag.Nome}, seu {ag.Servico} foi confirmado para {ag.FormatadoPtBr()}.";

    public string EnviarLembrete(Agendamento ag) =>
        $"[APP] Lembrete: {ag.Servico} às {ag.FormatadoPtBr()} (chegue 5 min antes).";
}
