using System;
using System.Collections.Generic;
using Fase8.Domain;
using Fase8.Domain.Interfaces;

namespace Fase8.UseCases
{
    // Consumidor de LEITURA (ISP)
    public sealed class AgendaQuery
    {
        private readonly IReadAgendamentoRepository _read;

        public AgendaQuery(IReadAgendamentoRepository read) => _read = read;

        public Agendamento? PorId(Guid id) => _read.Get(id);
        public IReadOnlyList<Agendamento> Todos() => _read.ListAll();

        public IEnumerable<Agendamento> DoDia(DateTime dia)
        {
            var de = new DateTime(dia.Year, dia.Month, dia.Day, 0, 0, 0);
            var ate = de.AddDays(1).AddTicks(-1);
            return _read.ListByDateRange(de, ate);
        }
    }
}
