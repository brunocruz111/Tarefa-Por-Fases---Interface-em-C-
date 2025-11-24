using System;
using Fase8.Domain;
using Fase8.Domain.Interfaces;

namespace Fase8.UseCases
{
    // Consumidor de ESCRITA (ISP)
    public sealed class AgendamentoCommands
    {
        private readonly IWriteAgendamentoRepository _write;
        private readonly IReadAgendamentoRepository _read;

        // opcional: injetar o read para comandos que precisam ler antes de escrever (ex.: update)
        public AgendamentoCommands(IWriteAgendamentoRepository write, IReadAgendamentoRepository read)
        {
            _write = write;
            _read  = read;
        }

        public Agendamento Criar(string nome, string servico, DateTime quando)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatório.");
            if (string.IsNullOrWhiteSpace(servico)) throw new ArgumentException("Serviço obrigatório.");

            var a = new Agendamento
            {
                Id = Guid.NewGuid(),
                Nome = nome.Trim(),
                Servico = servico.Trim(),
                Quando = quando
            };
            _write.Add(a);
            return a;
        }

        public bool Reagendar(Guid id, DateTime novaData)
        {
            var a = _read.Get(id);
            if (a is null) return false;
            a.Reagendar(novaData);
            return _write.Update(a);
        }

        public bool Cancelar(Guid id) => _write.Remove(id);
    }
}
