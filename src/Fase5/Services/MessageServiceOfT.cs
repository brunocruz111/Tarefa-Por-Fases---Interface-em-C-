using System;
using AgendaBem.Fase5.Domain.Interfaces;

namespace AgendaBem.Fase5.Services
{
    // Serviço genérico que exige que T implemente IMessageGenerator.
    // O uso de "where T : IMessageGenerator, new()" garante em tempo de compilação
    // que apenas tipos válidos podem ser usados.
    public class MessageServiceOfT<T> where T : IMessageGenerator, new()
    {
        // Usa uma instância existente
        public string CreateFor(T instance, string name, string service, DateTime dateTime)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            return instance.Generate(name, service, dateTime);
        }

        // Cria uma nova instância de T (por causa do new())
        public string CreateUsingNew(string name, string service, DateTime dateTime)
        {
            var instance = new T();
            return instance.Generate(name, service, dateTime);
        }
    }
}
