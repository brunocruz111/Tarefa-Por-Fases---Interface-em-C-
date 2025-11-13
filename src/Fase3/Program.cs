using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // 5 cenários (mesmos da Fase 2), agora sem if/switch no cliente:
        Imprimir("confirmação", "João",  "Corte",          new DateTime(2025, 11, 15, 15, 0, 0));
        Imprimir("lembrete",    "Marcos","Barba",          new DateTime(2025, 11, 16, 10, 30, 0));
        Imprimir("reagendamento","Pedro","Corte e Barba",  new DateTime(2025, 11, 20, 18, 0, 0));
        Imprimir("x",           "Lucas", "Corte",          new DateTime(2025, 11, 21, 9, 0, 0)); // padrão
        Imprimir("confirmação", "",      "Corte",          new DateTime(2025, 11, 22, 14, 0, 0)); // fronteira: nome vazio
    }

    private static void Imprimir(string tipo, string nome, string servico, DateTime quando)
    {
        var msg = MensagemFactory.Criar(tipo, nome, servico, quando);
        Console.WriteLine(msg.Gerar());
    }
}
