using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Fase9.Domain
{
    // Abstração do tempo (para não usar DateTime.Now direto e evitar Thread.Sleep em testes)
    public interface IClock
    {
        DateTimeOffset Now { get; }
    }

    // Abstração de geração de ID
    public interface IIdGenerator
    {
        string NewId();
    }

    // Leitor assíncrono (Stream)
    public interface IAsyncReader<T>
    {
        IAsyncEnumerable<T> ReadAllAsync(CancellationToken ct = default);
    }

    // Escritor assíncrono
    public interface IAsyncWriter<T>
    {
        Task WriteAsync(T item, CancellationToken ct = default);
    }
}