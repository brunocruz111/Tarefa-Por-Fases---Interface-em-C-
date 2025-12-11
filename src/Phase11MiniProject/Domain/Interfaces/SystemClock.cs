using System;
using System.Threading;
using System.Threading.Tasks;
using Phase09AsyncDoubles.Domain.Contracts;

namespace Phase09AsyncDoubles.Infrastructure;

// No mundo real, usamos o Task.Delay de verdade
public class SystemClock : IClock
{
    public async Task Delay(TimeSpan timeSpan, CancellationToken ct = default)
    {
        await Task.Delay(timeSpan, ct);
    }
}