namespace Phase08IspRepository.Domain.Interfaces;

// Interface segregada: apenas quem precisa ALTERAR dados depende disto.
public interface IWriteRepository<T, TId>
{
    T Add(T entity);
    bool Update(T entity);
    bool Remove(TId id);
}