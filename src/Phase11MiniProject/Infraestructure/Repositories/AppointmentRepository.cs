using System.Collections.Generic;
using System.Linq;
using Phase11MiniProject.Domain;
using Phase11MiniProject.Domain.Interfaces;
using Phase11MiniProject.Infrastructure.Context;

namespace Phase11MiniProject.Infrastructure.Repositories;

public class AppointmentRepository : IRepository<Appointment, int>
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Appointment entity)
    {
        _context.Appointments.Add(entity);
        _context.SaveChanges(); // Persiste no SQLite
    }

    public Appointment? GetById(int id)
    {
        return _context.Appointments.Find(id);
    }

    public List<Appointment> ListAll()
    {
        return _context.Appointments.ToList();
    }

    public void Update(Appointment entity)
    {
        _context.Appointments.Update(entity);
        _context.SaveChanges();
    }

    public void Remove(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _context.Appointments.Remove(entity);
            _context.SaveChanges();
        }
    }
}