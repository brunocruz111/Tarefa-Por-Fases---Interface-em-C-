namespace Phase06IspHandsOn.Domain.Interfaces;

// Segregação de Interface: Capacidade apenas de lembrar
public interface IReminderNotifier
{
    string SendReminder(Appointment appointment);
}