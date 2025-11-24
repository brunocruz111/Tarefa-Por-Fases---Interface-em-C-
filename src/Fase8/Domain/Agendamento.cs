using System;
using System.Globalization;

namespace Fase8.Domain
{
    public sealed class Agendamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Servico { get; set; } = string.Empty;
        public DateTime Quando { get; set; }

        public void Reagendar(DateTime novaData) => Quando = novaData;

        public override string ToString()
        {
            var pt = new CultureInfo("pt-BR");
            return $"[{Id}] {Nome} - {Servico} - {Quando.ToString("dd/MM 'às' HH:mm", pt)}";
        }
    }
}
