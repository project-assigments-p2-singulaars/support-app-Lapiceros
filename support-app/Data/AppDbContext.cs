using Microsoft.EntityFrameworkCore;

namespace support_app.Data;

public class AppDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Task.Task> Tasks { get; set; }
}