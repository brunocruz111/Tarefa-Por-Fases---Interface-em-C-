using System;
using System.Threading;
using System.Threading.Tasks;
using Phase09AsyncDoubles.Domain.Contracts;

namespace Phase09AsyncDoubles.Tests.Fakes;

// Dublê Inteligente: Não espera tempo real, mas registra que o atraso foi solicitado.
public class FakeClock : IClock
{
    public TimeSpan TotalWaited { get; private set; } = TimeSpan.Zero;

    public Task Delay(TimeSpan timeSpan, CancellationToken ct = default)
    {
        // Apenas soma o tempo, não executa Thread.Sleep!
        TotalWaited += timeSpan;
        return Task.CompletedTask;
    }
}