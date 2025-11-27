using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fase7.Domain.interfaces;
using Fase7.Domain;

namespace Fase7.Infra
{
    public sealed class JsonAgendamentoRepository : IAgendamentoRepository
    {
        private readonly string _path;

        private static readonly JsonSerializerOptions _opts = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };

        public JsonAgendamentoRepository(string path)
        {
            _path = path;
        }

        public void Add(Agendamento ag)
        {
            var list = Load();
            var i = list.FindIndex(x => x.Id == ag.Id);
            if (i >= 0) list[i] = ag; else list.Add(ag);
            Save(list);
        }

        public Agendamento? Get(Guid id)
            => Load().FirstOrDefault(a => a.Id == id);

        // NOVO: implementação do ListAll
        public IReadOnlyList<Agendamento> ListAll()
            => Load();

        public IEnumerable<Agendamento> ListByDateRange(DateTime de, DateTime ate)
            => Load().Where(a => a.Quando >= de && a.Quando <= ate)
                     .OrderBy(a => a.Quando)
                     .ToList();

        public bool Update(Agendamento ag)
        {
            var list = Load();
            var i = list.FindIndex(x => x.Id == ag.Id);
            if (i < 0) return false;
            list[i] = ag;
            Save(list);
            return true;
        }

        public bool Remove(Guid id)
        {
            var list = Load();
            var ok = list.RemoveAll(a => a.Id == id) > 0;
            if (ok) Save(list);
            return ok;
        }

        public bool Exists(Guid id) => Load().Any(a => a.Id == id);

        private List<Agendamento> Load()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            if (string.IsNullOrWhiteSpace(json)) return new();
            return JsonSerializer.Deserialize<List<Agendamento>>(json, _opts) ?? new();
        }

        private void Save(List<Agendamento> list)
        {
            var dir = Path.GetDirectoryName(_path);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var json = JsonSerializer.Serialize(list, _opts);
            File.WriteAllText(_path, json);
        }
    }
}
