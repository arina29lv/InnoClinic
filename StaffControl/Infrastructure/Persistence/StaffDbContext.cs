using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using StaffControl.Domain.Entities;

namespace StaffControl.Infrastructure.Persistence
{
    public class StaffDbContext : DbContext 
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Receptionist> Receptionists => Set<Receptionist>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(entity => 
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(d => d.MiddleName)
                .HasMaxLength(50);

                entity.Property(d => d.DateOfBirth)
                .IsRequired();

                entity.Property(d => d.AccountId)
                .IsRequired();

                entity.Property(d => d.SpecializationId)
                .IsRequired();

                entity.Property(d => d.OfficeId)
                .IsRequired();

                entity.Property(d => d.CareerStartYear)
                .IsRequired();

                entity.Property(d => d.Status)
                .IsRequired();
            });

            modelBuilder.Entity<Receptionist>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.MiddleName)
                .HasMaxLength(50);

                entity.Property(r => r.AccountId)
               .IsRequired();

                entity.Property(r => r.OfficeId)
                .IsRequired();
            });
        }
    }
}
