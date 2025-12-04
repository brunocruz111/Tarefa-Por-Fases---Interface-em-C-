namespace Fase11.Domain.Interfaces;

// Interface genérica de Escrita (ISP)
public interface IWriteRepository<T, TId>
{
    T Add(T entity);
    bool Update(T entity);
    bool Remove(TId id);
}