using System;

namespace AgendaBem.Fase5.Domain.Interfaces
{
    // Interface responsável por formatar detalhes da mensagem.
    // Representa uma capacidade adicional independente de gerar a mensagem completa.
    public interface IMessageFormatter
    {
        string FormatDetails(string name, string service, DateTime dateTime);
    }
}
