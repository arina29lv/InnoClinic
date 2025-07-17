using AccountControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountControl.Infrastructure.Persistence
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) {}

        public DbSet<Account> Accounts => Set<Account>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasIndex(a => a.Email)
                .IsUnique();

                entity.Property(a => a.Email)                     
                .IsRequired()         
                .HasMaxLength(100);

                entity.Property(a => a.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(a => a.IsEmailVerified)
                .IsRequired();

                entity.Property(a => a.PhotoId);

                entity.Property(a => a.CreatedBy)
                .IsRequired();

                entity.Property(a => a.CreatedAt)
                .IsRequired();

                entity.Property(a => a.UpdatedBy);

                entity.Property(a => a.UpdatedAt);
            });
        }   
        
        
    }
}
