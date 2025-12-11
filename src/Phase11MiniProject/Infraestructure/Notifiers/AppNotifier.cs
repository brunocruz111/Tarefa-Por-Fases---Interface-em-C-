using Phase06IspHandsOn.Domain;
using Phase06IspHandsOn.Domain.Interfaces;

namespace Phase06IspHandsOn.Infrastructure.Notifiers;

// App não faz Reagendamento
public sealed class AppNotifier : 
    IConfirmationNotifier, IReminderNotifier
{
    public string SendConfirmation(Appointment app) =>
        $"[APP] {app.ClientName}, seu {app.ServiceType} foi confirmado.";

    public string SendReminder(Appointment app) =>
        $"[APP] Lembrete: {app.ServiceType} às {app.FormatToPtBr()} (chegue 5 min antes).";
}