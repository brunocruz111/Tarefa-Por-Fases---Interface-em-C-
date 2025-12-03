using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fase9.Domain;
using Fase9.Services;
using Fase9.Doubles;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("=== FASE 9: Testes Assíncronos e Dublês Avançados ===\n");

        await Teste1_SucessoSimples();
        await Teste2_RetentativaComSucesso();
        await Teste3_CancelamentoNoMeio();
        await Teste4_StreamVazio();
    }

    // Cenário 1: Tudo funciona
    static async Task Teste1_SucessoSimples()
    {
        Console.WriteLine("--- Teste 1: Fluxo de Sucesso ---");
        var dados = new[] { new Agendamento("1", "A"), new Agendamento("2", "B"), new Agendamento("3", "C") };
        
        var reader = new FakeReader<Agendamento>(dados);
        var writer = new StubBrokenWriter<Agendamento>(0); // 0 falhas
        var clock = new FakeClock();

        var service = new DataPumpService<Agendamento>(reader, writer, clock);
        int processados = await service.RunAsync(CancellationToken.None);

        Assert(processados == 3, $"Esperado 3, processados {processados}");
        Assert(writer.WrittenItems.Count == 3, "Writer deve ter recebido 3 itens");
        Console.WriteLine("✅ Teste 1 Passou\n");
    }

    // Cenário 2: Writer falha 2x, depois escreve (Retentativa)
    static async Task Teste2_RetentativaComSucesso()
    {
        Console.WriteLine("--- Teste 2: Retentativa (Backoff simulado) ---");
        var dados = new[] { new Agendamento("1", "Dificil") };

        var reader = new FakeReader<Agendamento>(dados);
        var writer = new StubBrokenWriter<Agendamento>(2); // Falha 2x, passa na 3ª
        var clock = new FakeClock();

        var service = new DataPumpService<Agendamento>(reader, writer, clock);
        int processados = await service.RunAsync(CancellationToken.None);

        Assert(processados == 1, $"Esperado 1, processados {processados}");
        Assert(writer.WrittenItems.Count == 1, "Item deveria ter sido escrito após retentativas");
        Console.WriteLine("✅ Teste 2 Passou\n");
    }

    // Cenário 3: Cancelamento via CancellationToken
    static async Task Teste3_CancelamentoNoMeio()
    {
        Console.WriteLine("--- Teste 3: Cancelamento ---");
        var dados = new[] { new Agendamento("1", "A"), new Agendamento("2", "B"), new Agendamento("3", "C") };
        
        // Delay de 100ms para dar tempo de cancelar
        var reader = new FakeReader<Agendamento>(dados, delayMs: 100); 
        var writer = new StubBrokenWriter<Agendamento>(0);
        var clock = new FakeClock();

        var cts = new CancellationTokenSource();
        var service = new DataPumpService<Agendamento>(reader, writer, clock);

        var task = service.RunAsync(cts.Token);
        
        // Cancela após um tempo curto
        await Task.Delay(150); 
        cts.Cancel();

        int processados = await task;

        // Espera-se que tenha processado pelo menos 1, mas não todos
        Assert(processados < 3, $"Não deveria processar todos. Processados: {processados}");
        Console.WriteLine("✅ Teste 3 Passou\n");
    }

    // Cenário 4: Lista vazia
    static async Task Teste4_StreamVazio()
    {
        Console.WriteLine("--- Teste 4: Stream Vazio ---");
        var reader = new FakeReader<Agendamento>(new List<Agendamento>());
        var writer = new StubBrokenWriter<Agendamento>(0);
        var clock = new FakeClock();

        var service = new DataPumpService<Agendamento>(reader, writer, clock);
        int processados = await service.RunAsync(CancellationToken.None);

        Assert(processados == 0, $"Esperado 0, processados {processados}");
        Console.WriteLine("✅ Teste 4 Passou\n");
    }

    static void Assert(bool condition, string message)
    {
        if (!condition)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FALHA] {message}");
            Console.ResetColor();
        }
    }
}