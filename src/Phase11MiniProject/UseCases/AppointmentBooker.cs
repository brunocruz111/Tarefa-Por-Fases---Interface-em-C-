using Phase08IspRepository.Domain;
using Phase08IspRepository.Domain.Interfaces;

namespace Phase08IspRepository.UseCases;

public class AppointmentBooker
{
    // Depende de Escrita (e poderia depender de leitura se precisasse validar)
    private readonly IWriteRepository<Appointment, int> _repository;

    public AppointmentBooker(IWriteRepository<Appointment, int> repository)
    {
        _repository = repository;
    }

    public void Book(string client, string service, DateTime date)
    {
        var appt = new Appointment(0, client, service, date);
        var created = _repository.Add(appt);
        Console.WriteLine($"[Booker] Agendado com sucesso! ID: {created.Id}");
    }
}