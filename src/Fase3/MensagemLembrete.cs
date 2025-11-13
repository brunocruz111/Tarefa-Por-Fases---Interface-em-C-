using System;

public sealed class MensagemLembrete : MensagemAgendamento
{
    public MensagemLembrete(string nome, string servico, DateTime quando)
        : base(nome, servico, quando) { }

    protected override string MontarTexto()
    {
        var dt = FormatarDataHora();
        return $"Olá, {Nome}! Só lembrando do seu horário de {Servico} hoje às {dt}. Chegue com 5 min de antecedência ";
    }
}
