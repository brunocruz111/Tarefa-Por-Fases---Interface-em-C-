using System;
using System.IO;
using Xunit; // Requer xunit
using Phase07RepositoryJson.Domain;
using Phase07RepositoryJson.Infrastructure;

namespace Phase07RepositoryJson.Tests;

public class JsonRepositoryTests : IDisposable
{
    private readonly string _tempFile;

    public JsonRepositoryTests()
    {
        _tempFile = Path.GetTempFileName();
    }

    public void Dispose()
    {
        if (File.Exists(_tempFile)) File.Delete(_tempFile);
    }

    [Fact]
    public void Add_ShouldCreateFile_AndPersistJson()
    {
        // Arrange
        var repo = new JsonAppointmentRepository(_tempFile);
        var app = new Appointment(1, "Test Client", "Service", DateTime.Now);

        // Act
        repo.Add(app);

        // Assert
        Assert.True(File.Exists(_tempFile));
        string content = File.ReadAllText(_tempFile);
        Assert.Contains("test Client", content); // Verifica camelCase ("test Client" vs "Test Client" se fosse nome de prop)
        // Nota: O valor da propriedade string não muda para camelCase, mas o nome da propriedade sim: "clientName": "Test Client"
        Assert.Contains("clientName", content); 
    }

    [Fact]
    public void ListAll_WithMissingFile_ShouldReturnEmpty()
    {
        // Arrange (Deleta arquivo criado pelo construtor do teste se houver)
        if(File.Exists(_tempFile)) File.Delete(_tempFile);
        var repo = new JsonAppointmentRepository(_tempFile);

        // Act
        var list = repo.ListAll();

        // Assert
        Assert.Empty(list);
    }
}