using LogControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LogControl.Infrastructure.Persistence
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }

        public DbSet<Log> Logs => Set<Log>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Log>(entity =>
            {

                entity.Property(l => l.Level)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(l => l.MicroserviceName)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(l => l.Message)
                .IsRequired();

                entity.Property(l => l.Exception)
                .IsRequired(false);

                entity.Property(l => l.Environment)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(l => l.Time)
                .IsRequired();
            });
        }
    }
}
