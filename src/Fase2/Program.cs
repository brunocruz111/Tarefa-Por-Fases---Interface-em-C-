using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // 1) Tipo válido – confirmação
        Console.WriteLine(MessageGenerator.Generate(
            "confirmação", "João", "Corte", new DateTime(2025, 11, 15, 15, 0, 0)));

        // 2) Tipo válido – lembrete
        Console.WriteLine(MessageGenerator.Generate(
            "lembrete", "Marcos", "Barba", new DateTime(2025, 11, 16, 10, 30, 0)));

        // 3) Tipo válido – reagendamento
        Console.WriteLine(MessageGenerator.Generate(
            "reagendamento", "Pedro", "Corte e Barba", new DateTime(2025, 11, 20, 18, 0, 0)));

        // 4) Tipo desconhecido – cai no padrão
        Console.WriteLine(MessageGenerator.Generate(
            "outroValor", "Lucas", "Corte", new DateTime(2025, 11, 21, 9, 0, 0)));

        // 5) Campo faltando / vazio – mostra fragilidade do procedural (sem validação)
        Console.WriteLine(MessageGenerator.Generate(
            "confirmação", "", "Corte", new DateTime(2025, 11, 22, 14, 0, 0)));
    }
}
