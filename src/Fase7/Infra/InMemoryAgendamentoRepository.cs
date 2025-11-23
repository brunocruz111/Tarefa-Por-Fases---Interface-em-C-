using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Fase07.Contracts;
using Fase07.Domain;

namespace Fase07.Infra;

public sealed class InMemoryAgendamentoRepository : IAgendamentoRepository
{
    // Estrutura interna escondida do consumidor
    private readonly Dictionary<Guid, Agendamento> _data = new();
    private readonly ReaderWriterLockSlim _lock = new();

    public void Add(Agendamento ag)
    {
        _lock.EnterWriteLock();
        try { _data.Add(ag.Id, ag); }
        finally { _lock.ExitWriteLock(); }
    }

    public Agendamento? Get(Guid id)
    {
        _lock.EnterReadLock();
        try { return _data.TryGetValue(id, out var ag) ? ag : null; }
        finally { _lock.ExitReadLock(); }
    }

    public IEnumerable<Agendamento> ListByDateRange(DateTime de, DateTime ate)
    {
        _lock.EnterReadLock();
        try
        {
            return _data.Values
                        .Where(a => a.Quando >= de && a.Quando <= ate)
                        .OrderBy(a => a.Quando)
                        .ToList(); // materializa para sair do lock
        }
        finally { _lock.ExitReadLock(); }
    }

    public void Update(Agendamento ag)
    {
        _lock.EnterWriteLock();
        try
        {
            if (!_data.ContainsKey(ag.Id))
                throw new InvalidOperationException("Agendamento não encontrado para atualizar.");

            _data[ag.Id] = ag;
        }
        finally { _lock.ExitWriteLock(); }
    }

    public bool Remove(Guid id)
    {
        _lock.EnterWriteLock();
        try { return _data.Remove(id); }
        finally { _lock.ExitWriteLock(); }
    }

    public bool Exists(Guid id)
    {
        _lock.EnterReadLock();
        try { return _data.ContainsKey(id); }
        finally { _lock.ExitReadLock(); }
    }
}
