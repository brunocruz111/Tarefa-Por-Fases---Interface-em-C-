using System;
using System.Collections.Generic;
using Fase7.Contracts;
using Fase7.Domain;

namespace Fase7.UseCases
{
    public sealed class AgendamentoService
    {
        private readonly IAgendamentoRepository _repo;

        public AgendamentoService(IAgendamentoRepository repo) => _repo = repo;

        public Agendamento Criar(string nome, string servico, DateTime quando)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatório.");
            if (string.IsNullOrWhiteSpace(servico)) throw new ArgumentException("Serviço obrigatório.");

            var ag = new Agendamento
            {
                Id = Guid.NewGuid(),
                Nome = nome.Trim(),
                Servico = servico.Trim(),
                Quando = quando
            };
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

        // NOVO: expõe o ListAll do repositório
        public IReadOnlyList<Agendamento> ListarTodos() => _repo.ListAll();

        public bool Reagendar(Guid id, DateTime novaData)
        {
            var ag = _repo.Get(id);
            if (ag is null) return false;
            ag.Reagendar(novaData);
            return _repo.Update(ag);
        }

        public bool Cancelar(Guid id) => _repo.Remove(id);
    }
}
