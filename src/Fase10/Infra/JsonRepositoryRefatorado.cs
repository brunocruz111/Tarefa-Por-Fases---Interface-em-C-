using System;
using System.Collections.Generic;
using System.Text.Json;
using Fase10.Infra;

namespace Fase10.Infra;

public record Agendamento(Guid Id, string Nome, string Servico);

public class JsonRepositoryRefatorado
{
    private readonly IFileSystem _fs; 
    private readonly string _path;

    public JsonRepositoryRefatorado(IFileSystem fs, string path)
    {
        _fs = fs;
        _path = path;
    }

    public void Adicionar(Agendamento ag)
    {
        var lista = LerTodos();
        lista.Add(ag);
        Salvar(lista);
    }

    public List<Agendamento> LerTodos()
    {
        if (!_fs.Existe(_path)) return new List<Agendamento>();
        
        var json = _fs.LerArquivo(_path);
        if (string.IsNullOrWhiteSpace(json)) return new List<Agendamento>();

        return JsonSerializer.Deserialize<List<Agendamento>>(json) ?? new List<Agendamento>();
    }

    private void Salvar(List<Agendamento> lista)
    {
        var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
        _fs.EscreverArquivo(_path, json);
    }
}