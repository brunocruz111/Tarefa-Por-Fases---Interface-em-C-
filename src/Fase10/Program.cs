using System;
using Fase10.Refactorings;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== FASE 10: Cheiros e Antídotos ===\n");

        TesteSemDisco();
        Console.WriteLine();
        TesteExtensibilidadeFactory();
    }

    // PROVA 1: Testando repositório sem tocar no HD (rápido e seguro)
    static void TesteSemDisco()
    {
        Console.WriteLine("--- 1. Teste de I/O com Fake (Memória) ---");
        
        var fakeFs = new FakeFileSystem();
        var repo = new RepositorioRefatorado(fakeFs, "banco.txt");

        // Ação
        repo.Salvar("Dados Importantes");

        // Verificação: Checamos a memória do Fake, não o disco C:\
        bool salvou = fakeFs.Arquivos.ContainsKey("banco.txt") && 
                      fakeFs.Arquivos["banco.txt"] == "Dados Importantes";

        if (salvou)
            Console.WriteLine("✅ SUCESSO: Repositório persistiu na memória (Fake).");
        else
            Console.WriteLine("❌ FALHA: Não persistiu corretamente.");
    }

    // PROVA 2: Adicionando um novo tipo de mensagem SEM mexer na classe Factory
    static void TesteExtensibilidadeFactory()
    {
        Console.WriteLine("--- 2. Teste de Extensibilidade (OCP) ---");

        var factory = new FactoryRefatorada();

        // 1. Testa tipo existente
        Console.WriteLine($"Tipo 'ola': {factory.Criar("ola").Gerar()}");

        // 2. O Antídoto permite isso: Registrar novo tipo em tempo de execução
        factory.Registrar("promo", () => new MsgPromo());
        
        var msgNova = factory.Criar("promo");
        bool funcionou = msgNova.Gerar() == "Promoção 50% OFF!";
        
        if (funcionou)
            Console.WriteLine("✅ SUCESSO: Novo tipo 'promo' adicionado sem alterar a Factory.");
        else
            Console.WriteLine("❌ FALHA: Extensão falhou.");
    }

    // Classe criada apenas para o teste, simulando um plugin ou nova feature
    class MsgPromo : IMensagem { public string Gerar() => "Promoção 50% OFF!"; }
}