using System;
using System.Collections.Generic;

namespace Fase8.Domain.Interfaces
{
    public interface IReadAgendamentoRepository
    {
        Agendamento? Get(Guid id);
        IReadOnlyList<Agendamento> ListAll();
        IEnumerable<Agendamento> ListByDateRange(DateTime de, DateTime ate);
    }
}
