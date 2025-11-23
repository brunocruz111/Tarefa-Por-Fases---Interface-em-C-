using Fase06.Contracts;
using Fase06.Domain;

namespace Fase06.UseCases;

public sealed class ConfirmacaoService
{
    private readonly INotificaConfirmacao _canal;

    public ConfirmacaoService(INotificaConfirmacao canal) => _canal = canal;

    public string Executar(Agendamento ag) => _canal.EnviarConfirmacao(ag);
}
