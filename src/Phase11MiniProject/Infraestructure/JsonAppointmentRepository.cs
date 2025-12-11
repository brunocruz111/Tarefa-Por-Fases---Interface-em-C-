using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phase08IspRepository.Domain;
using Phase08IspRepository.Domain.Interfaces;

namespace Phase08IspRepository.Infrastructure;

// Esta classe é "potente": sabe ler e escrever.
// Mas o mundo exterior vê-a através das interfaces limitadas.
public sealed class JsonAppointmentRepository : 
    IReadRepository<Appointment, int>, 
    IWriteRepository<Appointment, int>
{
    private readonly string _filePath;
    
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public JsonAppointmentRepository(string filePath)
    {
        _filePath = filePath;
    }

    // --- Implementação de IWriteRepository ---

    public Appointment Add(Appointment entity)
    {
        var list = LoadFile();
        
        // Lógica de ID
        int newId = entity.Id;
        if (newId <= 0)
        {
            newId = list.Count > 0 ? list.Max(a => a.Id) + 1 : 1;
        }

        var newEntity = entity with { Id = newId };
        list.Add(newEntity);
        SaveFile(list);
        
        return newEntity;
    }

    public bool Update(Appointment entity)
    {
        var list = LoadFile();
        var index = list.FindIndex(x => x.Id == entity.Id);

        if (index == -1) return false;

        list[index] = entity;
        SaveFile(list);
        return true;
    }

    public bool Remove(int id)
    {
        var list = LoadFile();
        var removed = list.RemoveAll(x => x.Id == id) > 0;
        if (removed) SaveFile(list);
        return removed;
    }

    // --- Implementação de IReadRepository ---

    public Appointment? GetById(int id)
    {
        return LoadFile().FirstOrDefault(x => x.Id == id);
    }

    public List<Appointment> ListAll()
    {
        return LoadFile();
    }

    // --- Helpers de I/O ---

    private List<Appointment> LoadFile()
    {
        if (!File.Exists(_filePath)) return new List<Appointment>();
        var json = File.ReadAllText(_filePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<Appointment>();

        try { return JsonSerializer.Deserialize<List<Appointment>>(json, _options) ?? new(); }
        catch { return new(); }
    }

    private void SaveFile(List<Appointment> list)
    {
        var json = JsonSerializer.Serialize(list, _options);
        File.WriteAllText(_filePath, json);
    }
}