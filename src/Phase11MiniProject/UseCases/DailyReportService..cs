using System;
using Phase08IspRepository.Domain;
using Phase08IspRepository.Domain.Interfaces;

namespace Phase08IspRepository.UseCases;

public class DailyReportService
{
    // Depende APENAS de Leitura (ISP aplicado)
    private readonly IReadRepository<Appointment, int> _repository;

    public DailyReportService(IReadRepository<Appointment, int> repository)
    {
        _repository = repository;
    }

    public void PrintReport()
    {
        var data = _repository.ListAll();
        Console.WriteLine($"\n=== Relatório de Agendamentos ({data.Count}) ===");
        foreach (var item in data)
        {
            Console.WriteLine($"- {item.ClientName}: {item.FormatToPtBr()}");
        }
        // Nota: Aqui dentro é impossível chamar _repository.Add() ou Remove(). 
        // O compilador protege o código.
    }
}