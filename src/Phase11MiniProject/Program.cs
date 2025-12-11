using System;
using System.Linq;
using Phase11MiniProject.Domain;
using Phase11MiniProject.Infrastructure.Context;
using Phase11MiniProject.Infrastructure.Repositories;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Fase 11: Mini Projeto com EF Core & SQLite ---");

        // 1. Configuração do Contexto
        // O 'using' garante que a conexão feche ao terminar
        using var context = new AppDbContext();

        // TRUQUE PARA AULA: 
        // Garante que o banco seja criado se não existir (evita ter que rodar Migrations manualmente na primeira vez)
        context.Database.EnsureCreated();

        // 2. Repositório
        var repository = new AppointmentRepository(context);

        // 3. Verifica dados existentes
        var existing = repository.ListAll();
        
        if (!existing.Any())
        {
            Console.WriteLine("\n[Banco Vazio] Criando dados iniciais...");
            
            repository.Add(new Appointment("Roberto Carlos", "Show Especial", DateTime.Now.AddDays(10)));
            repository.Add(new Appointment("Erasmo", "Composição", DateTime.Now.AddDays(11)));
            
            Console.WriteLine("-> Dados salvos no SQLite.");
        }
        else
        {
            Console.WriteLine($"\n[Banco Carregado] Encontrados {existing.Count} registros:");
            foreach (var item in existing)
            {
                Console.WriteLine($"ID: {item.Id} | {item.ClientName} - {item.FormatToPtBr()}");
            }
        }

        // 4. Teste Rápido de Edição
        var first = repository.ListAll().FirstOrDefault();
        if (first != null)
        {
            Console.WriteLine($"\nAtualizando o ID {first.Id}...");
            first.ServiceType += " (Confirmado)";
            repository.Update(first);
            Console.WriteLine("Atualizado com sucesso.");
        }
    }
}