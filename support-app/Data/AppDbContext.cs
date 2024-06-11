using Microsoft.EntityFrameworkCore;
using support_app.Projects;

namespace support_app.Data;

public class AppDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Task.Task> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }
}