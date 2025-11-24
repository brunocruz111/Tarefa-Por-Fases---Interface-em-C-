using Fase06.Domain;
using Fase06.Domain.Interfaces;

namespace Fase06.Services;

public sealed class WhatsAppNotifier :
    INotificaConfirmacao, INotificaLembrete, INotificaReagendamento
{
    public string EnviarConfirmacao(Agendamento ag) =>
        $"[WA] Olá, {ag.Nome}! Seu agendamento para {ag.Servico} foi confirmado para {ag.FormatadoPtBr()}.";

    public string EnviarLembrete(Agendamento ag) =>
        $"[WA] Lembrete: {ag.Nome}, {ag.Servico} hoje às {ag.FormatadoPtBr()}.";

    public string EnviarReagendamento(Agendamento ag) =>
        $"[WA] Reagendado: {ag.Nome}, novo horário de {ag.Servico}: {ag.FormatadoPtBr()}.";
}
