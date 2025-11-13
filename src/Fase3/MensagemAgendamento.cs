using System;
using System.Globalization;

public abstract class MensagemAgendamento
{
    protected string Nome { get; }
    protected string Servico { get; }
    protected DateTime Quando { get; }
    protected CultureInfo PtBr { get; } = new CultureInfo("pt-BR");

    protected MensagemAgendamento(string nome, string servico, DateTime quando)
    {
        Nome = nome ?? string.Empty;
        Servico = servico ?? string.Empty;
        Quando = quando;
    }

    public string Gerar()
    {
        return MontarTexto();
    }

    protected abstract string MontarTexto();

    protected string FormatarDataHora() => Quando.ToString("dd/MM 'às' HH:mm", PtBr);
}
