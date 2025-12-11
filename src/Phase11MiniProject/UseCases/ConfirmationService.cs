using Phase06IspHandsOn.Domain;
using Phase06IspHandsOn.Domain.Interfaces;

namespace Phase06IspHandsOn.UseCases;

public sealed class ConfirmationService
{
    // Depende apenas da capacidade de confirmar
    private readonly IConfirmationNotifier _notifier;

    public ConfirmationService(IConfirmationNotifier notifier)
    {
        _notifier = notifier;
    }

    public string Execute(Appointment appointment)
    {
        return _notifier.SendConfirmation(appointment);
    }
}