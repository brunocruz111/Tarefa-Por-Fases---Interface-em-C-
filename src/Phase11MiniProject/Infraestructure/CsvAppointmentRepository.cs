using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Phase06IspHandsOn.Domain;
using Phase06IspHandsOn.Domain.Interfaces;

namespace Phase06IspHandsOn.Infrastructure;

public class CsvAppointmentRepository : IRepository<Appointment, int>
{
    private readonly string _filePath;

    public CsvAppointmentRepository(string filePath)
    {
        _filePath = filePath;
    }

    public int NextId()
    {
        if (!File.Exists(_filePath)) return 1;

        var lines = File.ReadAllLines(_filePath, Encoding.UTF8);
        if (lines.Length <= 1) return 1; // Apenas cabeçalho

        // Pega a última linha para saber o último ID
        var lastLine = lines[^1];
        var parts = SplitCsvLine(lastLine);
        
        if (parts.Length > 0 && int.TryParse(parts[0], out int lastId))
        {
            return lastId + 1;
        }
        return 1;
    }

    public List<Appointment> Load()
    {
        var list = new List<Appointment>();
        if (!File.Exists(_filePath)) return list;

        var lines = File.ReadAllLines(_filePath, Encoding.UTF8);

        // Pula o cabeçalho (i=1)
        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            var parts = SplitCsvLine(lines[i]);
            if (parts.Length < 4) continue;

            int id = int.Parse(parts[0]);
            string name = parts[1];
            string service = parts[2];
            // Usa InvariantCulture ou formato específico para garantir leitura correta do ISO 8601
            DateTime date = DateTime.Parse(parts[3], CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

            list.Add(new Appointment(id, name, service, date));
        }
        return list;
    }

    public void Save(List<Appointment> items)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Id,ClientName,ServiceType,Date");

        foreach (var item in items)
        {
            sb.Append(Escape(item.Id.ToString())).Append(',')
              .Append(Escape(item.ClientName)).Append(',')
              .Append(Escape(item.ServiceType)).Append(',')
              .Append(Escape(item.Date.ToString("o", CultureInfo.InvariantCulture))) // ISO 8601
              .AppendLine();
        }

        File.WriteAllText(_filePath, sb.ToString(), Encoding.UTF8);
    }

    // Utilitários de CSV
    private static string Escape(string value)
    {
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }
        return value;
    }

    private static string[] SplitCsvLine(string line)
    {
        // Parser simplificado que respeita aspas
        var result = new List<string>();
        var current = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"') // Aspas duplas escapadas
                {
                    current.Append('\"');
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(c);
            }
        }
        result.Add(current.ToString());
        return result.ToArray();
    }
}