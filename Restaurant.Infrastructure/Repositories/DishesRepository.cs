using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistance;

namespace Restaurant.Infrastructure.Repositories
{
    internal class DishesRepository(RestaurantDbContext dbContext) : IDishesRepository
    {
       
        public async Task<int> Create(Dish entity)
        {
            dbContext.Dishes.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteDishAsync(IEnumerable<Dish> entity)
        {

            dbContext.RemoveRange(entity);
            await dbContext.SaveChangesAsync();

        }

        //public async Task<IEnumerable<Restaurants>> GetAllAsync()
        //{
        //    var restaurants = await dbContext.Restaurants.ToListAsync();
        //    return restaurants;
        //}

        //public async Task<Restaurants?> GetByIdAsync(int id)
        //{
        //    return await dbContext.Restaurants
        //        .Include(r => r.Dishes)
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public Task UpdateChanges() => dbContext.SaveChangesAsync();

    }
}
