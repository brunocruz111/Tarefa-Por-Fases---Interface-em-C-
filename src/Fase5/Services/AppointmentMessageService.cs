using System;
using AgendaBem.Fase5.Domain.Interfaces;

namespace AgendaBem.Fase5.Services
{
    // Serviço responsável por gerar mensagens de agendamento.
    // Ele recebe um "resolver", ou seja: uma função que devolve
    // uma implementação de IMessageGenerator com base em uma string.
    //
    // Este é o padrão B1, excelente para testabilidade:
    // - Em produção: passar MessageFactory.Create
    // - Em testes: passar uma função que devolve um fake
    public class AppointmentMessageService
    {
        private readonly Func<string, IMessageGenerator> _resolver;

        public AppointmentMessageService(Func<string, IMessageGenerator> resolver)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public string CreateMessage(string type, string name, string service, DateTime dateTime)
        {
            var generator = _resolver(type);
            return generator.Generate(name, service, dateTime);
        }
    }
}
