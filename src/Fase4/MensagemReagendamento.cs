using System;
using System.Globalization;

public class MensagemReagendamento : IMensagem
{
    public string Gerar(string nome, string servico, DateTime dataHora)
    {
        var pt = new CultureInfo("pt-BR");
        var dt = dataHora.ToString("dd/MM 'às' HH:mm", pt);

        return $"Olá, {nome}! Seu agendamento de {servico} foi alterado para {dt}.";
    }
}
