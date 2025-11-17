using System;

public static class MensagemFactory
{
    /// Seleciona a implementação correta de IMensagem
    /// sem expor classes concretas ao cliente.
    public static IMensagem Criar(string tipo)
    {
        if (string.IsNullOrWhiteSpace(tipo))
            return new MensagemPadrao();

        var t = tipo.Trim().ToLowerInvariant();

        return t switch
        {
            "confirmação" => new MensagemConfirmacao(),
            "confirmacao" => new MensagemConfirmacao(),
            "lembrete" => new MensagemLembrete(),
            "reagendamento" => new MensagemReagendamento(),
            _ => new MensagemPadrao()
        };
    }
}
