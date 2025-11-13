using System;

public static class MensagemFactory
{
    public static MensagemAgendamento Criar(string tipo, string nome, string servico, DateTime quando)
    {
        var t = (tipo ?? string.Empty).Trim().ToLowerInvariant();

        switch (t)
        {
            case "confirmação":
            case "confirmacao":
                return new MensagemConfirmacao(nome, servico, quando);

            case "lembrete":
                return new MensagemLembrete(nome, servico, quando);

            case "reagendamento":
                return new MensagemReagendamento(nome, servico, quando);

            default:
                return new MensagemPadrao(nome, servico, quando);
        }
    }
}
