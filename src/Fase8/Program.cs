using System;
using System.IO;
using System.Linq;
using System.Text;
using Fase8.Infra;
using Fase8.UseCases;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // arquivo temporário para a demo
        var tempDir  = Path.Combine(Path.GetTempPath(), "agendabem_fase8_json");
        Directory.CreateDirectory(tempDir);
        var jsonPath = Path.Combine(tempDir, $"{Guid.NewGuid():N}.json");
        Console.WriteLine($"[demo] arquivo: {jsonPath}\n");

        // composição ISP: um repo de leitura e outro de escrita, mesmo arquivo
        var readRepo  = new JsonReadRepository(jsonPath);
        var writeRepo = new JsonWriteRepository(jsonPath);

        var query    = new AgendaQuery(readRepo);
        var commands = new AgendamentoCommands(writeRepo, readRepo);

        // criar
        var a1 = commands.Criar("João",  "Corte",         new DateTime(2025,11,15,15,00,00));
        var a2 = commands.Criar("Marcos","Barba",         new DateTime(2025,11,15,10,30,00));
        var a3 = commands.Criar("Pedro", "Corte e Barba", new DateTime(2025,11,20,18,00,00));

        Console.WriteLine("Todos (após criar):");
        foreach (var a in query.Todos()) Console.WriteLine(a);
        Console.WriteLine();

        // listar dia
        Console.WriteLine("Agenda 15/11:");
        foreach (var a in query.DoDia(new DateTime(2025,11,15))) Console.WriteLine(a);
        Console.WriteLine();

        // reagendar
        commands.Reagendar(a2.Id, new DateTime(2025,11,16,10,30,00));
        Console.WriteLine("Após reagendar Marcos para 16/11:");
        foreach (var a in query.DoDia(new DateTime(2025,11,16))) Console.WriteLine(a);
        Console.WriteLine();

        // cancelar
        commands.Cancelar(a1.Id);
        Console.WriteLine("Após cancelar João (15/11):");
        foreach (var a in query.DoDia(new DateTime(2025,11,15))) Console.WriteLine(a);
        Console.WriteLine();

        // prova de persistência (reabrir leitura)
        var read2 = new JsonReadRepository(jsonPath);
        var query2 = new AgendaQuery(read2);
        Console.WriteLine("Reabrindo e listando todos (persistência JSON):");
        foreach (var a in query2.Todos()) Console.WriteLine(a);
    }
}
