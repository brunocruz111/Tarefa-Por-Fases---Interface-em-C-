using System;
using System.Collections.Generic;
using System.Linq;
using Fase8.Domain;
using Fase8.Domain.Interfaces;

namespace Fase8.Infra
{
    public sealed class JsonReadRepository : IReadAgendamentoRepository
    {
        private readonly JsonFileStore<Agendamento> _store;

        public JsonReadRepository(string path)
        {
            _store = new JsonFileStore<Agendamento>(path);
        }

        public Agendamento? Get(Guid id)
            => _store.Load().FirstOrDefault(a => a.Id == id);

        public IReadOnlyList<Agendamento> ListAll()
            => _store.Load().OrderBy(a => a.Quando).ToList();

        public IEnumerable<Agendamento> ListByDateRange(DateTime de, DateTime ate)
            => _store.Load()
                     .Where(a => a.Quando >= de && a.Quando <= ate)
                     .OrderBy(a => a.Quando)
                     .ToList();
    }
}
