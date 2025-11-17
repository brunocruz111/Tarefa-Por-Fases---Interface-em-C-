using System;
using AgendaBem.Fase5.Domain.Interfaces;
using AgendaBem.Fase5.Domain.Messages;

namespace AgendaBem.Fase5.Services
{
    // Fábrica simples que retorna uma implementação de IMessageGenerator
    // com base na string recebida.
    // Serve como um ponto de composição para o padrão B1 (resolver).
    public static class MessageFactory
    {
        public static IMessageGenerator Create(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return new DefaultMessage();

            var t = type.Trim().ToLowerInvariant();

            return t switch
            {
                "confirmation" or "confirmacao" => new ConfirmationMessage(),
                "reminder" => new ReminderMessage(),
                _ => new DefaultMessage()
            };
        }
    }
}
