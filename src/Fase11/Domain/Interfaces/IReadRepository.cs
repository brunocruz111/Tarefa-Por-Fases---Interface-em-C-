using System.Collections.Generic;

namespace Fase11.Domain.Interfaces;

// Interface genérica de Leitura (ISP)
public interface IReadRepository<T, TId>
{
    IReadOnlyList<T> ListAll();
    T? GetById(TId id);
}