using System;
using System.Collections.Generic;

namespace Fase7.Domain.Interfaces
{
    public interface IAgendamentoRepository
    {
        void Add(Agendamento ag);
        Agendamento? Get(Guid id);
        IReadOnlyList<Agendamento> ListAll();
        IEnumerable<Agendamento> ListByDateRange(DateTime de, DateTime ate);
        bool Update(Agendamento ag);
        bool Remove(Guid id);
        bool Exists(Guid id);
    }

  
}
