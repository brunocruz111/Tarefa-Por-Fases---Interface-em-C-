using System;
using System.Text;
using System.Collections.Generic;
using Fase06.Domain;
using Fase06.Domain.Interfaces;
using Fase06.Services;
using Fase06.UseCases;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var repo = new CsvAgendamentoRepository("agendamentos.csv");

        // carregar agendamentos existentes
        var ags = repo.Load();

        // criar novos agendamentos com ID gerado pelo repositório
        var ag1 = new Agendamento(repo.NextId(), "João",  "Corte",          new DateTime(2025,11,15,15,00,00));
        var ag2 = new Agendamento(repo.NextId(), "Marcos","Barba",          new DateTime(2025,11,16,10,30,00));
        var ag3 = new Agendamento(repo.NextId(), "Pedro", "Corte e Barba",  new DateTime(2025,11,20,18,00,00));

        ags.AddRange(new[] { ag1, ag2, ag3 });

        // salvar no CSV
        repo.Save(ags);

        // composição de canais
        var whatsapp = new WhatsAppNotifier();
        var email    = new EmailNotifier();
        var app      = new AppNotifier();

        // casos de uso
        var confirmacao   = new ConfirmacaoService(whatsapp);
        var lembrete      = new LembreteService(app);
        var reagendamento = new ReagendamentoService(email);

        Console.WriteLine(confirmacao.Executar(ag1));
        Console.WriteLine(lembrete.Executar(ag2));
        Console.WriteLine(reagendamento.Executar(ag3));

        Console.WriteLine("\nArquivo CSV atualizado com sucesso!");
    }
}

