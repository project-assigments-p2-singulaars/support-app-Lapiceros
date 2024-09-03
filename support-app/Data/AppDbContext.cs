using Microsoft.EntityFrameworkCore;
using support_app.joinTable;
using support_app.Persons;
using support_app.Projects;
using support_app.Tasks;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;

namespace support_app.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Duty> Duties { get; set; }
    public DbSet<Role.Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProjectWorkerRol>()
            .HasKey(item => new { item.ProjectId, item.WorkerId, item.RoleId });
        
        modelBuilder.Entity<ProjectWorkerRol>()
            .HasOne(item => item.Project)
            .WithMany(x => x.ProjectWorkerRoles)
            .HasForeignKey(x => x.ProjectId);

        modelBuilder.Entity<ProjectWorkerRol>()
            .HasOne(item => item.Worker)
            .WithMany(x => x.ProjectWorkerRoles)
            .HasForeignKey(x => x.WorkerId);

        modelBuilder.Entity<ProjectWorkerRol>()
            .HasOne(item => item.Role)
            .WithMany(x => x.ProjectWorkerRoles)
            .HasForeignKey(x => x.RoleId);

        modelBuilder.Entity<Duty>()
            .HasOne(item => item.Project)
            .WithMany(x => x.SupportTask)
            .HasForeignKey(x => x.ProjectId);

        modelBuilder.Entity<Duty>()
            .HasOne(item => item.Worker)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.WorkerId);
    }

}