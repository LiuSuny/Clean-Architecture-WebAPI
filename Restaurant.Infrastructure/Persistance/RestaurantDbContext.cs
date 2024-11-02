using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistance
{
    internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
    {
        internal DbSet<Restaurants> Restaurants { get; set; }
         internal DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurants>()
             //this relation indicate that address model is owned by restaurants hence no need to add Id
             .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurants>()
                        .HasMany(r => r.Dishes)
                        .WithOne()
                        .HasForeignKey(x => x.RestaurantId);


        }
    }
}
