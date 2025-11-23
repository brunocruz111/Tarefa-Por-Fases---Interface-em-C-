using System;
using System.Globalization;

namespace Fase06.Domain;

public readonly record struct Agendamento(string Nome, string Servico, DateTime Quando)
{
    public string FormatadoPtBr() =>
        Quando.ToString("dd/MM 'às' HH:mm", new CultureInfo("pt-BR"));
}
