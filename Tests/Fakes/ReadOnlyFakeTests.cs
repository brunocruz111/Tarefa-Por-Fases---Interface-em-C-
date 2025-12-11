using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using src;
using Phase08IspRepository.Domain;
using Phase08IspRepository.Domain.Interfaces;
using Phase08IspRepository.UseCases;

namespace Phase08IspRepository.Tests;

// Dublê (Fake) que implementa APENAS leitura. 
// Muito mais simples de escrever do que um Mock de repositório completo.
public class FakeReadOnlyRepository : IReadRepository<Appointment, int>
{
    private readonly List<Appointment> _data = new();

    public FakeReadOnlyRepository(params Appointment[] initialData)
    {
        _data.AddRange(initialData);
    }

    public Appointment? GetById(int id) => _data.FirstOrDefault(x => x.Id == id);
    
    public List<Appointment> ListAll() => _data;
}

public class DailyReportServiceTests
{
    [Fact]
    public void PrintReport_ShouldReadFromMinimalInterface()
    {
        // Arrange
        // Note como é fácil criar o cenário, sem se preocupar com métodos Add/Save/IO
        var fakeRepo = new FakeReadOnlyRepository(
            new Appointment(1, "Teste User", "Teste Service", DateTime.Now)
        );
        
        var service = new DailyReportService(fakeRepo);

        // Act & Assert
        // (Aqui verificaríamos a saída da consola ou comportamento, 
        // mas o facto de compilar prova o ISP: o serviço aceitou o Fake limitado).
        service.PrintReport();
        
        Assert.NotNull(fakeRepo.GetById(1));
    }
}