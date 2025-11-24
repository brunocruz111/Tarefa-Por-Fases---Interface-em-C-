using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Fase06.Domain.Interfaces;

namespace Fase06.Domain;

// Implementação fiel ao PDF do professor (Repository CSV)
public class CsvAgendamentoRepository : IRepository<Agendamento, int>
{
    private readonly string _path;

    public CsvAgendamentoRepository(string path)
    {
        _path = path;
    }

    public int NextId()
    {
        if (!File.Exists(_path))
            return 1;

        var lines = File.ReadAllLines(_path, Encoding.UTF8);

        // Se só tem cabeçalho
        if (lines.Length <= 1)
            return 1;

        var last = lines[^1];
        var parts = SplitCsv(last);
        int id = int.Parse(parts[0]);

        return id + 1;
    }

    public List<Agendamento> Load()
    {
        var result = new List<Agendamento>();

        if (!File.Exists(_path))
            return result;

        var lines = File.ReadAllLines(_path, Encoding.UTF8);

        // pula cabeçalho
        for (int i = 1; i < lines.Length; i++)
        {
            var parts = SplitCsv(lines[i]);

            int id = int.Parse(parts[0]);
            string nome = parts[1];
            string servico = parts[2];
            DateTime quando = DateTime.Parse(parts[3], CultureInfo.InvariantCulture);

            result.Add(new Agendamento(id, nome, servico, quando));
        }

        return result;
    }

    public void Save(List<Agendamento> items)
    {
        var sb = new StringBuilder();

        // Cabeçalho igual ao PDF sugere
        sb.AppendLine("Id,Nome,Servico,Quando");

        foreach (var a in items)
        {
            sb.AppendLine(string.Join(",",
                Escape(a.Id.ToString()),
                Escape(a.Nome),
                Escape(a.Servico),
                Escape(a.Quando.ToString("o")) // ISO 8601 recomendado
            ));
        }

        File.WriteAllText(_path, sb.ToString(), Encoding.UTF8);
    }

    // ESCAPE CSV igual ao PDF
    private string Escape(string value)
    {
        if (value.Contains(',') || value.Contains('"'))
            return $"\"{value.Replace("\"", "\"\"")}\"";

        return value;
    }

    // SPLIT CSV – respeitando aspas
    private string[] SplitCsv(string line)
    {
        var result = new List<string>();
        var sb = new StringBuilder();
        bool quoted = false;

        foreach (char c in line)
        {
            if (c == '"')
            {
                quoted = !quoted;
                continue;
            }

            if (c == ',' && !quoted)
            {
                result.Add(sb.ToString());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }

        result.Add(sb.ToString());
        return result.ToArray();
    }
}
