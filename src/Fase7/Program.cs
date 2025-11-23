using System;
using System.Text;
using Fase07.Infra;
using Fase07.UseCases;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Composição em memória
        var repo = new InMemoryAgendamentoRepository();
        var service = new AgendamentoService(repo);

        // 1) Criar
        var a1 = service.Criar("João",  "Corte",         new DateTime(2025,11,15,15,00,00));
        var a2 = service.Criar("Marcos","Barba",         new DateTime(2025,11,15,10,30,00));
        var a3 = service.Criar("Pedro", "Corte e Barba", new DateTime(2025,11,20,18,00,00));

        Console.WriteLine("Criados:");
        Console.WriteLine(a1);
        Console.WriteLine(a2);
        Console.WriteLine(a3);
        Console.WriteLine();

        // 2) Listar por dia (15/11)
        Console.WriteLine("Agenda 15/11:");
        foreach (var ag in service.ListarDia(new DateTime(2025,11,15))) Console.WriteLine(ag);
        Console.WriteLine();

        // 3) Reagendar
        service.Reagendar(a2.Id, new DateTime(2025,11,16,10,30,00));
        Console.WriteLine("Após reagendar Marcos para 16/11:");
        foreach (var ag in service.ListarDia(new DateTime(2025,11,16))) Console.WriteLine(ag);
        Console.WriteLine();

        // 4) Cancelar
        service.Cancelar(a1.Id);
        Console.WriteLine("Após cancelar João (15/11):");
        foreach (var ag in service.ListarDia(new DateTime(2025,11,15))) Console.WriteLine(ag);
    }
}
