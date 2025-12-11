using Xunit;
using System.IO;
using System.Collections.Generic;
using System;
using src;
using Phase11MiniProject.Infrastructure;
using Phase11MiniProject.Domain;

namespace Tests.CsvRepositoryTests;

public class CsvRepositoryTests : IDisposable
{
    private readonly string _tempFile;

    public CsvRepositoryTests()
    {
        _tempFile = Path.GetTempFileName();
    }

    public void Dispose()
    {
        if (File.Exists(_tempFile)) File.Delete(_tempFile);
    }

    [Fact]
    public void SaveAndLoad_ShouldPersistDataCorrectly()
    {
        // Arrange
        var repo = new CsvAppointmentRepository(_tempFile);
        var appt = new Appointment(1, "Teste", "Servico", DateTime.Now);
        var list = new List<Appointment> { appt };

        // Act
        repo.Save(list);
        var loadedList = repo.Load();

        // Assert
        Assert.Single(loadedList);
        Assert.Equal("Teste", loadedList[0].ClientName);
    }

    [Fact]
    public void NextId_ShouldIncrementCorrectly()
    {
        // Arrange
        var repo = new CsvAppointmentRepository(_tempFile);
        repo.Save(new List<Appointment> 
        { 
            new Appointment(10, "A", "S", DateTime.Now) 
        });

        // Act
        var nextId = repo.NextId();

        // Assert
        Assert.Equal(11, nextId);
    }
}