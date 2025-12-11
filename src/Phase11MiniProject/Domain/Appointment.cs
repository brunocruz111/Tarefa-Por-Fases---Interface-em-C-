using System;
using System.Globalization;

namespace Phase11MiniProject.Domain;

public class Appointment
{
    public int Id { get; set; } // O EF Core identifica isso como Primary Key (Auto Increment)
    public string ClientName { get; set; } = string.Empty;
    public string ServiceType { get; set; } = string.Empty;
    public DateTime Date { get; set; }

    // Construtor vazio necessário para o EF Core materializar o objeto
    public Appointment() { }

    public Appointment(string clientName, string serviceType, DateTime date)
    {
        ClientName = clientName;
        ServiceType = serviceType;
        Date = date;
    }

    public string FormatToPtBr() =>
        Date.ToString("dd/MM 'às' HH:mm", new CultureInfo("pt-BR"));
}