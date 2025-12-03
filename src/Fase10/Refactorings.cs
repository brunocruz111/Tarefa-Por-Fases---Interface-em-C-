using System;
using System.Collections.Generic;
using System.IO;

namespace Fase10.Refactorings
{
    // =================================================================
    // CHEIRO 1: Acoplamento I/O -> ANTÍDOTO: Abstração (Seam)
    // =================================================================
    
    // Contrato que isola o disco (Costura)
    public interface IFileSystem
    {
        string ReadAllText(string path);
        void WriteAllText(string path, string content);
        bool Exists(string path);
    }

    // Implementação Real (usada no App final)
    public class RealFileSystem : IFileSystem
    {
        public string ReadAllText(string path) => File.ReadAllText(path);
        public void WriteAllText(string p, string c) => File.WriteAllText(p, c);
        public bool Exists(string path) => File.Exists(path);
    }

    // Implementação Fake (usada nos Testes - Antídoto para lentidão)
    public class FakeFileSystem : IFileSystem
    {
        // Simula o disco na memória RAM
        public Dictionary<string, string> Arquivos { get; } = new();

        public string ReadAllText(string path) => Arquivos.ContainsKey(path) ? Arquivos[path] : "";
        public void WriteAllText(string path, string c) => Arquivos[path] = c;
        public bool Exists(string path) => Arquivos.ContainsKey(path);
    }

    // Repositório refatorado para depender da interface, não do File estático
    public class RepositorioRefatorado
    {
        private readonly IFileSystem _fs;
        private readonly string _path;

        public RepositorioRefatorado(IFileSystem fs, string path)
        {
            _fs = fs;
            _path = path;
        }

        public void Salvar(string dados) => _fs.WriteAllText(_path, dados);
        public string Ler() => _fs.Exists(_path) ? _fs.ReadAllText(_path) : "Vazio";
    }

    // =================================================================
    // CHEIRO 2: Switch Gigante -> ANTÍDOTO: Catálogo (Map)
    // =================================================================

    public interface IMensagem { string Gerar(); }
    
    public class MsgOla : IMensagem { public string Gerar() => "Olá!"; }
    public class MsgTchau : IMensagem { public string Gerar() => "Tchau!"; }
    public class MsgPadrao : IMensagem { public string Gerar() => "..."; }

    // Fábrica refatorada: Em vez de um switch hardcoded, usa um Dicionário.
    // Isso permite adicionar novos tipos sem recompilar a classe (OCP).
    public class FactoryRefatorada
    {
        private readonly Dictionary<string, Func<IMensagem>> _catalogo = new();

        public FactoryRefatorada()
        {
            // Configuração inicial (padrão)
            Registrar("ola", () => new MsgOla());
            Registrar("tchau", () => new MsgTchau());
        }

        // Método que permite extensão (Antídoto para rigidez)
        public void Registrar(string chave, Func<IMensagem> criador) 
            => _catalogo[chave] = criador;

        public IMensagem Criar(string tipo)
        {
            // Se existir no catálogo, cria; senão, devolve padrão.
            return _catalogo.ContainsKey(tipo) ? _catalogo[tipo]() : new MsgPadrao();
        }
    }
}