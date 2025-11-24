using Fase06.Domain;
using Fase06.Domain.Interfaces;

namespace Fase06.UseCases;

public sealed class LembreteService
{
    private readonly INotificaLembrete _canal;

    public LembreteService(INotificaLembrete canal) => _canal = canal;

    public string Executar(Agendamento ag) => _canal.EnviarLembrete(ag);
}
