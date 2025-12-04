using System;
using System.Collections.Generic;
using System.Linq;
using Fase11.Domain;
using Fase11.Domain.Interfaces;

namespace Fase11.Infra;

public class InMemoryRepository : IReadRepository<Agendamento, Guid>, IWriteRepository<Agendamento, Guid>
{
    private readonly List<Agendamento> _items = new();

    public Agendamento Add(Agendamento entity)
    {
        // Se vier sem ID, gera um novo
        if (entity.Id == Guid.Empty)
            entity = entity with { Id = Guid.NewGuid() };
            
        _items.Add(entity);
        return entity;
    }

    public Agendamento? GetById(Guid id) => _items.FirstOrDefault(x => x.Id == id);

    public IReadOnlyList<Agendamento> ListAll() => _items.AsReadOnly();

    public bool Remove(Guid id)
    {
        var item = GetById(id);
        if (item == null) return false;
        return _items.Remove(item);
    }

    public bool Update(Agendamento entity)
    {
        var index = _items.FindIndex(x => x.Id == entity.Id);
        if (index == -1) return false;
        _items[index] = entity;
        return true;
    }
}