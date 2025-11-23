using System;
using System.Collections.Generic;
using Fase07.Contracts;
using Fase07.Domain;

namespace Fase07.UseCases;

public sealed class AgendamentoService
{
    private readonly IAgendamentoRepository _repo;

    public AgendamentoService(IAgendamentoRepository repo) => _repo = repo;

    public Agendamento Criar(string nome, string servico, DateTime quando)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatório.");
        if (string.IsNullOrWhiteSpace(servico)) throw new ArgumentException("Serviço obrigatório.");

        var ag = new Agendamento(Guid.NewGuid(), nome.Trim(), servico.Trim(), quando);
        _repo.Add(ag);
        return ag;
    }

    public Agendamento? Obter(Guid id) => _repo.Get(id);

    public IEnumerable<Agendamento> ListarDia(DateTime dia)
    {
        var de = new DateTime(dia.Year, dia.Month, dia.Day, 0, 0, 0);
        var ate = de.AddDays(1).AddTicks(-1);
        return _repo.ListByDateRange(de, ate);
    }

    public void Reagendar(Guid id, DateTime novaData)
    {
        var ag = _repo.Get(id) ?? throw new InvalidOperationException("Agendamento não encontrado.");
        ag.Reagendar(novaData);
        _repo.Update(ag);
    }

    public bool Cancelar(Guid id) => _repo.Remove(id);
}
