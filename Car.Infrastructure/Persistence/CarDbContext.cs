/*using Car.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Persistence
{
    public class CarDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }
        //public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Domain.Entities.Car> Cars { get; set; }

        public DbSet<Repair> Repairs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Domain.Entities.Car>()
            //    .OwnsOne(c => c.ContactDetails);
            modelBuilder.Entity<ApplicationUser>()
                .OwnsOne(u => u.ContactDetails);
            //modelBuilder.Entity<Repair>()
            //    .HasOne(r => r.Mechanic)
            //    .WithMany(u => u.Repairs)
            //    .HasForeignKey(r => r.Id_Mechanic)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Domain.Entities.Car>()
        .HasOne(c => c.User)
        .WithMany(u => u.Cars)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Cascade); // Lub inne zachowanie, np. Restrict

            modelBuilder.Entity<Repair>()
                .HasOne(r => r.Mechanic)
                .WithMany(u => u.Repairs)
                .HasForeignKey(r => r.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
 */

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

            // Skonfiguruj detale kontaktowe dla ApplicationUser
            modelBuilder.Entity<ApplicationUser>()
                .OwnsOne(u => u.ContactDetails);

            // Związek między Car a User (ApplicationUser)
            modelBuilder.Entity<Domain.Entities.Car>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja między Repair a Mechanic
            modelBuilder.Entity<Repair>()
                .HasOne(r => r.Mechanic)
                .WithMany(u => u.Repairs)
                .HasForeignKey(r => r.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
