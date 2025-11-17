using System;

/// Serviço de agendamento que recebe um resolvedor de IMensagem (ex: MensagemFactory.Criar)
/// Isso permite injetar um dublê facilmente em testes.
public class MensagemAgendamentoService
{
    private readonly Func<string, IMensagem> _resolvedor;

    // resolvedor: normalmente MensagemFactory.Criar, mas em testes pode ser substituído
    public MensagemAgendamentoService(Func<string, IMensagem> resolvedor)
    {
        _resolvedor = resolvedor ?? throw new ArgumentNullException(nameof(resolvedor));
    }

    public string Gerar(string tipo, string nome, string servico, DateTime dataHora)
    {
        var mensagem = _resolvedor(tipo);
        return mensagem.Gerar(nome, servico, dataHora);
    }
}
