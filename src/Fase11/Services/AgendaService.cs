using System;
using System.Collections.Generic;
using Fase11.Domain;
using Fase11.Domain.Interfaces;

namespace Fase11.Services;

public class AgendaService
{
    private readonly IReadRepository<Agendamento, Guid> _read;
    private readonly IWriteRepository<Agendamento, Guid> _write;

    // Injeção de dependência (ISP)
    public AgendaService(IReadRepository<Agendamento, Guid> read, IWriteRepository<Agendamento, Guid> write)
    {
        _read = read;
        _write = write;
    }

    public Agendamento Agendar(string nome, string servico, DateTime data)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatório");
        
        var ag = new Agendamento(Guid.Empty, nome, servico, data);
        return _write.Add(ag);
    }

    public IReadOnlyList<Agendamento> ListarAgenda() => _read.ListAll();

    public Agendamento? Buscar(Guid id) => _read.GetById(id);

    // Reagendar = Update
    public bool Reagendar(Guid id, DateTime novaData)
    {
        var ag = _read.GetById(id);
        if (ag is null) return false;

        var novoAg = ag with { DataHora = novaData };
        return _write.Update(novoAg);
    }

    public bool Cancelar(Guid id) => _write.Remove(id);
}