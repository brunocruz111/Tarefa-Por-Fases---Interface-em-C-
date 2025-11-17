using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Executar("confirmação", "João", "Corte", new DateTime(2025, 11, 15, 15, 0));
        Executar("lembrete", "Marcos", "Barba", new DateTime(2025, 11, 16, 10, 30));
        Executar("reagendamento", "Pedro", "Corte e Barba", new DateTime(2025, 11, 20, 18, 0));
        Executar("valor-invalido", "Lucas", "Corte", new DateTime(2025, 11, 21, 9, 0));
    }

    static void Executar(string tipo, string nome, string servico, DateTime data)
    {
        IMensagem mensagem = MensagemFactory.Criar(tipo);
        Console.WriteLine(mensagem.Gerar(nome, servico, data));
        Console.WriteLine("------------------------------------------------");
    }
}
