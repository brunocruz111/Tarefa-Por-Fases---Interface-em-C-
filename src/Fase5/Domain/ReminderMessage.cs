using System;
using System.Globalization;
using AgendaBem.Fase5.Domain.Interfaces;

namespace AgendaBem.Fase5.Domain.Messages
{
    // Classe que implementa duas interfaces normalmente (sem implementação explícita)
    // para comparar com a ConfirmationMessage.
    public class ReminderMessage : IMessageGenerator, IMessageFormatter
    {
        public string Generate(string name, string service, DateTime dateTime)
        {
            var culture = new CultureInfo("pt-BR");
            var dt = dateTime.ToString("dd/MM 'às' HH:mm", culture);
            return $"Olá, {name}! Lembrando do seu horário de {service} em {dt}.";
        }

        // Aqui a implementação é normal; aparece diretamente na classe,
        // diferentemente da implementação explícita usada na ConfirmationMessage.
        public string FormatDetails(string name, string service, DateTime dateTime)
        {
            var culture = new CultureInfo("pt-BR");
            var dt = dateTime.ToString("dd/MM 'às' HH:mm", culture);
            return $"{name} - {service} - {dt}";
        }
    }
}
