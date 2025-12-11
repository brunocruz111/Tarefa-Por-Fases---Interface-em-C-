using Microsoft.EntityFrameworkCore;
using Phase11MiniProject.Domain;

namespace Phase11MiniProject.Infrastructure.Context;

// Esta classe representa a sessão com o banco de dados
public class AppDbContext : DbContext
{
    // Mapeia a tabela "Appointments" baseada na classe Appointment
    public DbSet<Appointment> Appointments { get; set; }

    // Configura qual banco vamos usar (SQLite)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Cria um arquivo .db na raiz da execução
        optionsBuilder.UseSqlite("Data Source=app_database.db");
    }
}