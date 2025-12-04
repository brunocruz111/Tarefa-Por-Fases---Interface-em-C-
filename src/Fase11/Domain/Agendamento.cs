using System;

namespace Fase11.Domain;

// Record imutável representando o Agendamento
public sealed record Agendamento(
    Guid Id, 
    string NomeCliente, 
    string Servico, 
    DateTime DataHora
);