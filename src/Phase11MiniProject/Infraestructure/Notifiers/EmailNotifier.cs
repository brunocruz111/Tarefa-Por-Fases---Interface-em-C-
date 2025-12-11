using Phase06IspHandsOn.Domain;
using Phase06IspHandsOn.Domain.Interfaces;

namespace Phase06IspHandsOn.Infrastructure.Notifiers;

// Email não implementa Lembrete (decisão de negócio hipotética)
public sealed class EmailNotifier : 
    IConfirmationNotifier, IRescheduleNotifier
{
    public string SendConfirmation(Appointment app) =>
        $"[EMAIL] Confirmação — {app.ClientName}, {app.ServiceType} em {app.FormatToPtBr()}.";

    public string SendReschedule(Appointment app) =>
        $"[EMAIL] Alteração — {app.ClientName}, {app.ServiceType} para {app.FormatToPtBr()}.";
}