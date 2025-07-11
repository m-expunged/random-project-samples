using GuestManagement.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuestManagement.Data
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<Guest> Guests { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<CheckIn> CheckIns { get; set; }

        public DbSet<CheckInType> CheckInTypes { get; set; }

        public override int SaveChanges()
        {
            var timestamp = DateTimeOffset.Now;

            var entities = ChangeTracker.Entries<Entity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .ToList();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = timestamp;
                }

                entity.Entity.UpdatedAt = timestamp;
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context, _) =>
            {
                if (!context.Set<Gender>().Any())
                {
                    context.Set<Gender>().AddRange([
                        new Gender() { Name = "Male" },
                        new Gender() { Name = "Female" },
                        new Gender() { Name = "Other" }
                    ]);
                }

                if (!context.Set<CheckInType>().Any())
                {
                    context.Set<CheckInType>().AddRange([
                        new CheckInType() { Name = "In" },
                        new CheckInType() { Name = "Out" }
                    ]);
                }

                SaveChanges();
            });

            base.OnConfiguring(optionsBuilder);
        }
    }
}