using Microsoft.EntityFrameworkCore;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infrastructure.Data;

public class TimeSheetDbContext : DbContext
{
    public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Activity> Activity { get; set; }
    public DbSet<ProjectAssignment> ProjectAssignment { get; set; }
    public DbSet<ProjectActivity> ProjectActivity { get; set; }
    public DbSet<TimeLog> TimeLog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProjectActivity>()
            .HasKey(pa => new { pa.ProjectId, pa.ActivityId });

        modelBuilder.Entity<TimeLog>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasOne(d => d.ProjectActivity)
                    .WithMany(p => p.TimeLogs)
                    .HasForeignKey(d => new { d.ProjectId, d.ActivityId })
                    .OnDelete(DeleteBehavior.Restrict);

                    entity.Property(e => e.Hours)
                    .HasPrecision(18, 2);
                });

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<ProjectAssignment>(entity =>
        {
            entity.Property(pa => pa.IsActive)
            .HasDefaultValue(true);

            entity.HasIndex(pa => new { pa.UserId, pa.ProjectId })
            .IsUnique()
            .HasFilter("[IsActive] = 1");
        });

        modelBuilder.Entity<Activity>(entity =>
                {
                    entity.Property(a => a.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                    entity.HasIndex(a => a.Name)
                    .IsUnique();
                });

        modelBuilder.Entity<Project>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}
