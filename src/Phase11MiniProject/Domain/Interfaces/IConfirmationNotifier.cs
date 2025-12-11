namespace Phase06IspHandsOn.Domain.Interfaces;

// Segregação de Interface: Capacidade apenas de confirmar
public interface IConfirmationNotifier
{
    string SendConfirmation(Appointment appointment);
}