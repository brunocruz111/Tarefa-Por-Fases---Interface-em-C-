using System;

public sealed class MensagemPadrao : MensagemAgendamento
{
    public MensagemPadrao(string nome, string servico, DateTime quando)
        : base(nome, servico, quando) { }

    protected override string MontarTexto()
    {
        return $"Olá, {Nome}! Temos uma atualização sobre o seu agendamento. Consulte o app ou a barbearia.";
    }
}
