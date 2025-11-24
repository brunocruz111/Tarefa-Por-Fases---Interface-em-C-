using System;
using System.IO;
using System.Linq;
using System.Text;
using Fase7.Infra;
using Fase7.UseCases;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var tempDir  = Path.Combine(Path.GetTempPath(), "agendabem_fase7_json");
        Directory.CreateDirectory(tempDir);
        var jsonPath = Path.Combine(tempDir, $"{Guid.NewGuid():N}.json");

        Console.WriteLine($"[demo] usando arquivo: {jsonPath}\n");

        var repo    = new JsonAgendamentoRepository(jsonPath);
        var service = new AgendamentoService(repo);

        var a1 = service.Criar("João",  "Corte",         new DateTime(2025,11,15,15,00,00));
        var a2 = service.Criar("Marcos","Barba",         new DateTime(2025,11,15,10,30,00));
        var a3 = service.Criar("Pedro", "Corte e Barba", new DateTime(2025,11,20,18,00,00));

        Console.WriteLine("Todos (ListAll):");
        foreach (var a in service.ListarTodos())
            Console.WriteLine(a);
        Console.WriteLine();

        Console.WriteLine("Agenda 15/11:");
        foreach (var a in service.ListarDia(new DateTime(2025,11,15)))
            Console.WriteLine(a);
        Console.WriteLine();

        service.Reagendar(a2.Id, new DateTime(2025,11,16,10,30,00));
        Console.WriteLine("Após reagendar Marcos para 16/11:");
        foreach (var a in service.ListarDia(new DateTime(2025,11,16)))
            Console.WriteLine(a);
        Console.WriteLine();

        service.Cancelar(a1.Id);
        Console.WriteLine("Após cancelar João (15/11):");
        foreach (var a in service.ListarDia(new DateTime(2025,11,15)))
            Console.WriteLine(a);
        Console.WriteLine();

        // prova de persistência
        var repo2    = new JsonAgendamentoRepository(jsonPath);
        var service2 = new AgendamentoService(repo2);
        Console.WriteLine("Reabrindo arquivo e ListAll (persistência JSON):");
        foreach (var a in service2.ListarTodos())
            Console.WriteLine(a);
    }
}
