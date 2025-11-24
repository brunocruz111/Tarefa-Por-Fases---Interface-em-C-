using System.Collections.Generic;

namespace Fase06.Domain.Interfaces;

// Interface genérica inspirada no PDF (RepositorioCsv)
public interface IRepository<T, TId>
{
    List<T> Load();

    void Save(List<T> items);

    TId NextId();
}
