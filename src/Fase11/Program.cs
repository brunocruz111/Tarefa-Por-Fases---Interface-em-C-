using System;
using System.IO;
using Fase11.Domain;
using Fase11.Infra;
using Fase11.Services;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== FASE 11: Consolidação (AgendaBem) ===\n");

        ExecutarTestesUnitarios();

        Console.WriteLine("\n------------------------------------------\n");

        ExecutarDemoReal();
    }

    // 1. Testes Unitários: Usam InMemoryRepository (Rápido, sem disco)
    static void ExecutarTestesUnitarios()
    {
        Console.WriteLine("[TESTES] Rodando Unitários (InMemory)...");

        var repo = new InMemoryRepository();
        var service = new AgendaService(repo, repo);

        // Teste: Agendar
        var ag1 = service.Agendar("Teste Unitário", "Corte", DateTime.Now);
        Assert(ag1.Id != Guid.Empty, "ID deve ser gerado");
        Assert(service.ListarAgenda().Count == 1, "Deve ter 1 item");

        // Teste: Reagendar
        var novaData = DateTime.Now.AddDays(1);
        bool reagendou = service.Reagendar(ag1.Id, novaData);
        var atualizado = service.Buscar(ag1.Id);
        
        Assert(reagendou, "Reagendamento deve funcionar");
        Assert(atualizado!.DataHora == novaData, "Data deve ser atualizada");

        // Teste: Cancelar
        bool cancelou = service.Cancelar(ag1.Id);
        Assert(cancelou, "Cancelamento deve funcionar");
        Assert(service.ListarAgenda().Count == 0, "Agenda deve ficar vazia");

        Console.WriteLine("[TESTES] Todos passaram!");
    }

    // 2. Demo Real: Usa JsonRepository (Cria arquivo)
    static void ExecutarDemoReal()
    {
        var arquivo = "agenda_db.json";
        Console.WriteLine($" Usando Banco JSON: {arquivo}");

        var repo = new JsonRepository(arquivo);
        var service = new AgendaService(repo, repo);

        // Caso 1: Agendar
        var a1 = service.Agendar("João da Silva", "Barba", DateTime.Parse("2025-12-01 10:00"));
        var a2 = service.Agendar("Maria Oliveira", "Corte", DateTime.Parse("2025-12-01 11:00"));
        
        Console.WriteLine($"1. Agendado: {a1.NomeCliente} - {a1.Servico}");
        Console.WriteLine($"2. Agendado: {a2.NomeCliente} - {a2.Servico}");

        // Caso 2: Listar
        Console.WriteLine("\n[Agenda Atual]");
        foreach (var item in service.ListarAgenda())
            Console.WriteLine($" - {item.DataHora:dd/MM HH:mm}: {item.NomeCliente} ({item.Servico})");

        // Caso 3: Reagendar
        Console.WriteLine($"\n3. Reagendando João para 14:00...");
        service.Reagendar(a1.Id, DateTime.Parse("2025-12-01 14:00"));

        // Caso 4: Listar Final
        Console.WriteLine("\n[Agenda Final]");
        foreach (var item in service.ListarAgenda())
            Console.WriteLine($" - {item.DataHora:dd/MM HH:mm}: {item.NomeCliente} ({item.Servico})");
    }

    static void Assert(bool cond, string msg)
    {
        if (!cond)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERRO] {msg}");
            Console.ResetColor();
        }
    }
}