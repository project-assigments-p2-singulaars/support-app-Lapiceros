using Microsoft.EntityFrameworkCore;
using support_app.Persons;
using support_app.Projects;
using support_app.Tasks;

namespace support_app.Data;

public class AppDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Worker>  Workers { get; set; }
    public DbSet<Duty> Duties { get; set; }
}