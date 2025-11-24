using System;
using System.Collections.Generic;
using System.Linq;
using Fase8.Domain;
using Fase8.Domain.Interfaces;

namespace Fase8.Infra
{
    public sealed class JsonWriteRepository : IWriteAgendamentoRepository
    {
        private readonly JsonFileStore<Agendamento> _store;

        public JsonWriteRepository(string path)
        {
            _store = new JsonFileStore<Agendamento>(path);
        }

        public void Add(Agendamento a)
        {
            var list = _store.Load();
            var idx = list.FindIndex(x => x.Id == a.Id);
            if (idx >= 0) list[idx] = a; else list.Add(a);
            _store.Save(list);
        }

        public bool Update(Agendamento a)
        {
            var list = _store.Load();
            var idx = list.FindIndex(x => x.Id == a.Id);
            if (idx < 0) return false;
            list[idx] = a;
            _store.Save(list);
            return true;
        }

        public bool Remove(Guid id)
        {
            var list = _store.Load();
            var ok = list.RemoveAll(x => x.Id == id) > 0;
            if (ok) _store.Save(list);
            return ok;
        }

        public bool Exists(Guid id)
            => _store.Load().Any(x => x.Id == id);
    }
}
