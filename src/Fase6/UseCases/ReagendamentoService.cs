using Fase06.Domain;
using Fase06.Domain.Interfaces;

namespace Fase06.UseCases;

public sealed class ReagendamentoService
{
    private readonly INotificaReagendamento _canal;

    public ReagendamentoService(INotificaReagendamento canal) => _canal = canal;

    public string Executar(Agendamento ag) => _canal.EnviarReagendamento(ag);
}
