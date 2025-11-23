using Fase06.Contracts;
using Fase06.Domain;

namespace Fase06.UseCases;

public sealed class ReagendamentoService
{
    private readonly INotificaReagendamento _canal;

    public ReagendamentoService(INotificaReagendamento canal) => _canal = canal;

    public string Executar(Agendamento ag) => _canal.EnviarReagendamento(ag);
}
