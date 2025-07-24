using AppointmentControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentControl.Infrastructure.Persistence
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) {}

        public DbSet<Appointment> Appointments => Set<Appointment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.PatientId)
                .IsRequired();

                entity.Property(a => a.DoctorId)
                .IsRequired();

                entity.Property(a => a.ServiceId)
                .IsRequired();

                entity.Property(a => a.Date)
                .IsRequired()
                .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue),
                    v => DateOnly.FromDateTime(v)
                    );

                entity.Property(a => a.Time)
                .IsRequired()
                .HasConversion(
                    v => v.ToTimeSpan(),
                    v => TimeOnly.FromTimeSpan(v)
                    );

                entity.Property(a => a.IsApproved)
                .IsRequired();
            });
        }
    }
}
