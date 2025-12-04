using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Fase11.Domain;
using Fase11.Domain.Interfaces;

namespace Fase11.Infra;

public class JsonRepository : IReadRepository<Agendamento, Guid>, IWriteRepository<Agendamento, Guid>
{
    private readonly string _path;
    private readonly JsonSerializerOptions _opts = new() { WriteIndented = true };

    public JsonRepository(string path)
    {
        _path = path;
        // Cria arquivo vazio se não existir
        if (!File.Exists(_path)) File.WriteAllText(_path, "[]");
    }

    private List<Agendamento> Load()
    {
        var json = File.ReadAllText(_path);
        if (string.IsNullOrWhiteSpace(json)) return new List<Agendamento>();
        return JsonSerializer.Deserialize<List<Agendamento>>(json) ?? new List<Agendamento>();
    }

    private void Save(List<Agendamento> list)
    {
        var json = JsonSerializer.Serialize(list, _opts);
        File.WriteAllText(_path, json);
    }

    public Agendamento Add(Agendamento entity)
    {
        var list = Load();
        if (entity.Id == Guid.Empty)
            entity = entity with { Id = Guid.NewGuid() };

        list.Add(entity);
        Save(list);
        return entity;
    }

    public Agendamento? GetById(Guid id) => Load().FirstOrDefault(x => x.Id == id);

    public IReadOnlyList<Agendamento> ListAll() => Load();

    public bool Remove(Guid id)
    {
        var list = Load();
        var removed = list.RemoveAll(x => x.Id == id) > 0;
        if (removed) Save(list);
        return removed;
    }

    public bool Update(Agendamento entity)
    {
        var list = Load();
        var idx = list.FindIndex(x => x.Id == entity.Id);
        if (idx == -1) return false;

        list[idx] = entity;
        Save(list);
        return true;
    }
}