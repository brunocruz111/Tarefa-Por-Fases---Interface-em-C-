using System;

public sealed class MensagemConfirmacao : MensagemAgendamento
{
    public MensagemConfirmacao(string nome, string servico, DateTime quando)
        : base(nome, servico, quando) { }

    protected override string MontarTexto()
    {
        var dt = FormatarDataHora();
        return $"Olá, {Nome}! Seu agendamento para {Servico} foi confirmado para {dt}. Qualquer dúvida, fale com a barbearia.";
    }
}
