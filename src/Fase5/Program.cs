using System;
using System.Text;
using AgendaBem.Fase5.Domain.Interfaces;
using AgendaBem.Fase5.Domain.Messages;
using AgendaBem.Fase5.Services;

namespace AgendaBem.Fase5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ============================
            // 1) Uso do padrão B1 (resolver)
            // ============================
            Console.WriteLine("=== AppointmentMessageService com MessageFactory ===");
            var service = new AppointmentMessageService(MessageFactory.Create);
            Console.WriteLine(service.CreateMessage("confirmation", "João", "Corte", new DateTime(2025,11,15,15,0)));
            Console.WriteLine();

            // ====================
            // 2) Uso com dublê/fake
            // ====================
            Console.WriteLine("=== AppointmentMessageService com Fake ===");
            var fakeResolver = new Func<string, IMessageGenerator>(type => new FakeMessageGenerator());
            var fakeService = new AppointmentMessageService(fakeResolver);
            Console.WriteLine(fakeService.CreateMessage("anything", "Teste", "Serviço", DateTime.Now));
            Console.WriteLine();

            // =====================================
            // 3) Demonstração de implementação explícita
            // =====================================
            Console.WriteLine("=== Implementação explícita em ConfirmationMessage ===");
            var confirmation = new ConfirmationMessage();
            Console.WriteLine("Gerar (público): " + confirmation.Generate("Maria", "Barba", new DateTime(2025,11,16,10,30)));

            if (confirmation is IMessageFormatter formatter)
            {
                Console.WriteLine("FormatDetails (explícito): " + formatter.FormatDetails("Maria", "Barba", new DateTime(2025,11,16,10,30)));
            }
            Console.WriteLine();

            // =====================================
            // 4) Uso do serviço genérico com constraints
            // =====================================
            Console.WriteLine("=== Serviço genérico MessageServiceOfT ===");
            var genericService = new MessageServiceOfT<ReminderMessage>();
            var reminder = new ReminderMessage();
            Console.WriteLine(genericService.CreateFor(reminder, "Carlos", "Corte", new DateTime(2025,11,20,14,0)));
            Console.WriteLine();

            // CreateUsingNew()
            Console.WriteLine("=== CreateUsingNew ===");
            Console.WriteLine(genericService.CreateUsingNew("Ana", "Corte", new DateTime(2025,11,21,9,0)));
        }

        // Fake usado apenas para demonstrar testabilidade no resolver B1
        private class FakeMessageGenerator : IMessageGenerator
        {
            public string Generate(string name, string service, DateTime dateTime)
            {
                return $"[FAKE] Mensagem para {name} - {service}";
            }
        }
    }
}
