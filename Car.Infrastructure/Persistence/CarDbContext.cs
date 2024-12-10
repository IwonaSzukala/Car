using Car.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Car.Infrastructure.Persistence
{
    public class CarDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Car> Cars { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ApplicationUser>()
                .OwnsOne(u => u.ContactDetails);

            
            modelBuilder.Entity<Domain.Entities.Car>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Repair>()
                .HasOne(r => r.Mechanic)
                .WithMany(u => u.Repairs)
                .HasForeignKey(r => r.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
