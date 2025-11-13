using System;

public sealed class MensagemReagendamento : MensagemAgendamento
{
    public MensagemReagendamento(string nome, string servico, DateTime quando)
        : base(nome, servico, quando) { }

    protected override string MontarTexto()
    {
        var dt = FormatarDataHora();
        return $"Olá, {Nome}! Seu agendamento de {Servico} foi alterado para {dt}. Se não puder, responda.";
    }
}
