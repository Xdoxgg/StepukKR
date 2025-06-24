using Microsoft.EntityFrameworkCore;

namespace DantoBrick;

public class FullContext:DbContext
{
    public DbSet<User>  Users { get; set; }
    public DbSet<Doctor>  Doctors { get; set; }
    public DbSet<Service>  Services { get; set; }
    public DbSet<Appointment>  Appointments { get; set; }
    public DbSet<Review>  Reviews { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var connectionString = "Server=MSI\\MSSQLSERVER01;Database=sdb;Trusted_Connection=True; TrustServerCertificate=True; Encrypt=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}