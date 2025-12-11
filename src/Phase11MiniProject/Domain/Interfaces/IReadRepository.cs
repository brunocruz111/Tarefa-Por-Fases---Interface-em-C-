using System.Collections.Generic;

namespace Phase08IspRepository.Domain.Interfaces;

// Interface segregada: apenas quem precisa LER dados depende disto.
public interface IReadRepository<T, TId>
{
    T? GetById(TId id);
    List<T> ListAll();
}
