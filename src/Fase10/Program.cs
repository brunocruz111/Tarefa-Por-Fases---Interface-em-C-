using System;
using Fase10.Infra;
using Fase10.Services;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== FASE 10: Refatorações no AgendaBem ===\n");

        TesteRepositorioSemDisco();
        Console.WriteLine();
        TesteFactoryExtensivel();
    }

    static void TesteRepositorioSemDisco()
    {
        Console.WriteLine("--- 1. Repositório com FakeFileSystem ---");

        var fakeFs = new FakeFileSystem();
        var repo = new JsonRepositoryRefatorado(fakeFs, "agenda.json");

        repo.Adicionar(new Agendamento(Guid.NewGuid(), "Carlos", "Corte"));

        if (fakeFs.Arquivos.ContainsKey("agenda.json"))
        {
            Console.WriteLine("Sucesso: Agendamento salvo na memória.");
            Console.WriteLine($"   Conteúdo: {fakeFs.Arquivos["agenda.json"]}");
        }
        else
        {
            Console.WriteLine("Erro: Nada foi salvo.");
        }
    }

    static void TesteFactoryExtensivel()
    {
        Console.WriteLine("--- 2. Factory com Catálogo (OCP) ---");

        var factory = new MensagemFactoryRefatorada();

        Console.WriteLine("Normal: " + factory.Criar("confirmacao").Format("Ana", "Unha"));

        factory.Registrar("promo", () => new MsgPromocao());

        var msgPromo = factory.Criar("promo");
        Console.WriteLine("Novo Tipo: " + msgPromo.Format("Ana", "Unha")); 

        if (msgPromo is MsgPromocao)
            Console.WriteLine("Sucesso: Tipo 'promo' injetado sem alterar código da Factory.");
    }

    class MsgPromocao : IMensagem
    {
        public string Format(string n, string s) => $"Parabéns {n}, você ganhou 10% no serviço {s}!";
    }
}