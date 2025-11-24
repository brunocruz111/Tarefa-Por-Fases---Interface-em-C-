using System;
using System.Collections.Generic;
using Fase7.Domain;

namespace Fase7.Contracts
{
    public interface IAgendamentoRepository
    {
        void Add(Agendamento ag);
        Agendamento? Get(Guid id);

        // NOVO: listar todos
        IReadOnlyList<Agendamento> ListAll();

        IEnumerable<Agendamento> ListByDateRange(DateTime de, DateTime ate);
        bool Update(Agendamento ag);
        bool Remove(Guid id);
        bool Exists(Guid id);
    }
}
