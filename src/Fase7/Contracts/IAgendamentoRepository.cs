using System;
using System.Collections.Generic;
using Fase07.Domain;

namespace Fase07.Contracts;

public interface IAgendamentoRepository
{
    void Add(Agendamento ag);
    Agendamento? Get(Guid id);
    IEnumerable<Agendamento> ListByDateRange(DateTime de, DateTime ate);
    void Update(Agendamento ag);
    bool Remove(Guid id);
    bool Exists(Guid id);
}
