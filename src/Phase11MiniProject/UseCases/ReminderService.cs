using Phase06IspHandsOn.Domain;
using Phase06IspHandsOn.Domain.Interfaces;

namespace Phase06IspHandsOn.UseCases;

public sealed class ReminderService
{
    // Depende apenas da capacidade de lembrar
    private readonly IReminderNotifier _notifier;

    public ReminderService(IReminderNotifier notifier)
    {
        _notifier = notifier;
    }

    public string Execute(Appointment appointment)
    {
        return _notifier.SendReminder(appointment);
    }
}