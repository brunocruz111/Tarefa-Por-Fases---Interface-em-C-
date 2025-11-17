using System;
using System.Globalization;

public class MensagemLembrete : IMensagem
{
    public string Gerar(string nome, string servico, DateTime dataHora)
    {
        var pt = new CultureInfo("pt-BR");
        var dt = dataHora.ToString("dd/MM 'às' HH:mm", pt);

        return $"Olá, {nome}! Só lembrando do seu horário de {servico} hoje às {dt}.";
    }
}
