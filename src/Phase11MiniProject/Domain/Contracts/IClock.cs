using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phase09AsyncDoubles.Domain.Contracts;

// Abstração do Tempo (permite "avançar" o tempo nos testes instantaneamente)
public interface IClock
{
    // Substitui Thread.Sleep ou Task.Delay
    Task Delay(TimeSpan timeSpan, CancellationToken ct = default);
}