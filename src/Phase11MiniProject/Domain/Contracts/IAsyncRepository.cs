using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Phase09AsyncDoubles.Domain.Contracts;

public interface IAsyncRepository<T>
{
    // Uso de IAsyncEnumerable para Streaming (leitura item a item)
    IAsyncEnumerable<T> StreamAllAsync(CancellationToken ct = default);
    
    // Escrita assíncrona
    Task AddAsync(T entity, CancellationToken ct = default);
}