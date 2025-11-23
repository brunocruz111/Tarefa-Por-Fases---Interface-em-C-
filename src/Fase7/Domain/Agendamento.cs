using System;
using System.Globalization;

namespace Fase07.Domain;

public sealed class Agendamento
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public string Servico { get; private set; }
    public DateTime Quando { get; private set; }

    public Agendamento(Guid id, string nome, string servico, DateTime quando)
    {
        Id = id;
        Nome = nome ?? string.Empty;
        Servico = servico ?? string.Empty;
        Quando = quando;
    }

    public void Reagendar(DateTime novaData) => Quando = novaData;

    public override string ToString()
    {
        var pt = new CultureInfo("pt-BR");
        return $"[{Id}] {Nome} - {Servico} - {Quando.ToString("dd/MM 'às' HH:mm", pt)}";
    }
}
