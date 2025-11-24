using System;

namespace Fase8.Domain.Interfaces
{
    public interface IWriteAgendamentoRepository
    {
        void Add(Agendamento a);
        bool Update(Agendamento a);
        bool Remove(Guid id);
        bool Exists(Guid id);
    }
}
