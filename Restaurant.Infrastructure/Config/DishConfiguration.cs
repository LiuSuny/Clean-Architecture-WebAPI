using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Config
{
    public class DishConfiguration: IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
                builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
                
        }
    
    }
}
