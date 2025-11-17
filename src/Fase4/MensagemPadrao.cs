using System;
using System.Globalization;

public class MensagemPadrao : IMensagem
{
    public string Gerar(string nome, string servico, DateTime dataHora)
    {
        return $"Olá, {nome}! Temos uma atualização sobre o seu agendamento. Consulte o app ou a barbearia.";
    }
}
