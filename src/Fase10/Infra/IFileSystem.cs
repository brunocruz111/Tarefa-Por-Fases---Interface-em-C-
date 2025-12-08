using System.Collections.Generic;
using System.IO;

namespace Fase10.Infra;

public interface IFileSystem
{
    string LerArquivo(string caminho);
    void EscreverArquivo(string caminho, string conteudo);
    bool Existe(string caminho);
}

public class RealFileSystem : IFileSystem
{
    public string LerArquivo(string path) => File.ReadAllText(path);
    public void EscreverArquivo(string path, string content) => File.WriteAllText(path, content);
    public bool Existe(string path) => File.Exists(path);
}

public class FakeFileSystem : IFileSystem
{
    public Dictionary<string, string> Arquivos { get; } = new();

    public string LerArquivo(string path) => Arquivos.ContainsKey(path) ? Arquivos[path] : "";
    public void EscreverArquivo(string path, string content) => Arquivos[path] = content;
    public bool Existe(string path) => Arquivos.ContainsKey(path);
}