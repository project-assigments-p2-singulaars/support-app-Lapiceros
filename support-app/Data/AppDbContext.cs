using Microsoft.EntityFrameworkCore;
using support_app.Persons;
using support_app.Projects;
using support_app.Tasks;

namespace support_app.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Duty> Duties { get; set; }
    public DbSet<Role.Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Project>()
            .HasMany(pr => pr.SupportTask)
            .WithOne(sp => sp.Project)
            .HasForeignKey(sp => sp.Id);
        
        modelBuilder.Entity<Duty>()
            .HasOne(pr => pr.Worker)
            .WithOne(sp => sp.TaskAssigned)
            .HasForeignKey<Worker>(sp => sp.TaskId);
    }

}