using Fase06.Domain;

namespace Phase06IspHandsOn.Domain.Interfaces;

// Segregação de Interface: Capacidade apenas de reagendar
public interface IRescheduleNotifier
{
    string SendReschedule(Appointment appointment);
}