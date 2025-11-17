using System;
using System.Globalization;
using AgendaBem.Fase5.Domain.Interfaces;

namespace AgendaBem.Fase5.Domain.Messages
{
    // Classe que implementa DUAS interfaces:
    // - IMessageGenerator (pública)
    // - IMessageFormatter (implementação explícita, visível apenas via casting)
    public class ConfirmationMessage : IMessageGenerator, IMessageFormatter
    {
        // Implementação pública da geração de mensagem.
        public string Generate(string name, string service, DateTime dateTime)
        {
            var culture = new CultureInfo("pt-BR");
            var dt = dateTime.ToString("dd/MM 'às' HH:mm", culture);
            return $"Olá, {name}! Seu agendamento para {service} foi confirmado para {dt}.";
        }

        // Implementação EXPLÍCITA da interface IMessageFormatter.
        // Isso significa que este método NÃO aparece como método da classe,
        // apenas quando o objeto é convertido para IMessageFormatter.
        string IMessageFormatter.FormatDetails(string name, string service, DateTime dateTime)
        {
            var culture = new CultureInfo("pt-BR");
            var dt = dateTime.ToString("dd/MM 'às' HH:mm", culture);
            return $"{name} | {service} | {dt}";
        }
    }
}
