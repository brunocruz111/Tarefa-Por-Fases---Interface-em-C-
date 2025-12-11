using Phase06IspHandsOn.Domain;
using Phase06IspHandsOn.Domain.Interfaces;

namespace Phase06IspHandsOn.Infrastructure.Notifiers;

// Implementa TODAS as interfaces, pois o "Zap" faz tudo
public sealed class WhatsAppNotifier : 
    IConfirmationNotifier, IReminderNotifier, IRescheduleNotifier
{
    public string SendConfirmation(Appointment app) =>
        $"[WA] Olá {app.ClientName}! Seu agendamento de {app.ServiceType} foi confirmado para {app.FormatToPtBr()}.";

    public string SendReminder(Appointment app) =>
        $"[WA] Lembrete: {app.ClientName}, {app.ServiceType} hoje às {app.FormatToPtBr()}.";

    public string SendReschedule(Appointment app) =>
        $"[WA] Reagendado: {app.ClientName}, novo horário de {app.ServiceType}: {app.FormatToPtBr()}.";
}