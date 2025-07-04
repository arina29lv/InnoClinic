using Microsoft.EntityFrameworkCore;
using PatientControl.Domain.Entities;

namespace PatientControl.Infrastructure.Persistence
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions <PatientDbContext> options) : base(options) { }

        public DbSet<Patient> Patients => Set<Patient>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(p => p.MiddleName)
                .HasMaxLength(100);


                entity.Property(p => p.DateOfBirth)
                .IsRequired();

                entity.Property(P => P.IsLinkedToAccount)
                .IsRequired();

                entity.Property(p => p.AccountId)
                .IsRequired();
            });
        }

    }
}
