using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Fase9.Domain;

namespace Fase9.Doubles
{
    // Fake Clock: Permite fixar o tempo
    public class FakeClock : IClock
    {
        public DateTimeOffset Now { get; set; } = new DateTimeOffset(2025, 12, 01, 10, 0, 0, TimeSpan.Zero);
    }

    // Fake Reader: Emite uma lista fixa de itens via IAsyncEnumerable
    public class FakeReader<T> : IAsyncReader<T>
    {
        private readonly IEnumerable<T> _items;
        private readonly int _delayMs;

        public FakeReader(IEnumerable<T> items, int delayMs = 0)
        {
            _items = items;
            _delayMs = delayMs;
        }

        public async IAsyncEnumerable<T> ReadAllAsync([EnumeratorCancellation] CancellationToken ct = default)
        {
            foreach (var item in _items)
            {
                ct.ThrowIfCancellationRequested();
                if (_delayMs > 0) await Task.Delay(_delayMs, ct);
                yield return item;
            }
        }
    }

    // Writer Stub: Pode ser configurado para falhar N vezes
    public class StubBrokenWriter<T> : IAsyncWriter<T>
    {
        private int _failuresRemaining;
        public List<T> WrittenItems { get; } = new();

        public StubBrokenWriter(int failuresToSimulate)
        {
            _failuresRemaining = failuresToSimulate;
        }

        public Task WriteAsync(T item, CancellationToken ct = default)
        {
            if (_failuresRemaining > 0)
            {
                _failuresRemaining--;
                throw new Exception("Falha simulada de I/O");
            }

            WrittenItems.Add(item);
            return Task.CompletedTask;
        }
    }
}