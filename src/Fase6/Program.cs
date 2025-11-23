using System;
using System.Text;
using Fase06.Channels;
using Fase06.Domain;
using Fase06.UseCases;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var ag1 = new Agendamento("João",  "Corte",          new DateTime(2025,11,15,15,00,00));
        var ag2 = new Agendamento("Marcos","Barba",          new DateTime(2025,11,16,10,30,00));
        var ag3 = new Agendamento("Pedro", "Corte e Barba",  new DateTime(2025,11,20,18,00,00));

        // composição: escolhemos o canal por capacidade (sem obrigar o consumidor a conhecer tudo)
        var whatsapp = new WhatsAppNotifier();
        var email    = new EmailNotifier();
        var app      = new AppNotifier();

        // cada caso de uso depende apenas do contrato mínimo
        var confirmacao   = new ConfirmacaoService(whatsapp); // poderia trocar por email/app
        var lembrete      = new LembreteService(app);         // app implementa lembrete
        var reagendamento = new ReagendamentoService(email);  // email implementa reagendamento

        Console.WriteLine(confirmacao.Executar(ag1));
        Console.WriteLine(lembrete.Executar(ag2));
        Console.WriteLine(reagendamento.Executar(ag3));
    }
}
