using System.Globalization;

public static class MessageGenerator
{
    /// Gera o texto que será enviado ao cliente sobre o agendamento,
    /// variando conforme o tipo de notificação (procedural: if/switch).
    /// Modos: "confirmação"/"confirmacao", "lembrete", "reagendamento" e padrão.
    public static string Generate(string tipo, string nome, string servico, DateTime dataHora)
    {
        var t = (tipo ?? string.Empty).Trim().ToLowerInvariant();
        var pt = new CultureInfo("pt-BR");
        var dt = dataHora.ToString("dd/MM 'às' HH:mm", pt);

        switch (t)
        {
            case "confirmação":
            case "confirmacao":
                return $"Olá, {nome}! Seu agendamento para {servico} foi confirmado para {dt}. Qualquer dúvida, fale com a barbearia.";

            case "lembrete":
                return $"Olá, {nome}! Só lembrando do seu horário de {servico} hoje às {dt}. Chegue com 5 min de antecedência ";

            case "reagendamento":
                return $"Olá, {nome}! Seu agendamento de {servico} foi alterado para {dt}. Se não puder, responda.";

            default: // modo padrão
                return $"Olá, {nome}! Temos uma atualização sobre o seu agendamento. Consulte o app ou a barbearia.";
        }
    }
}
