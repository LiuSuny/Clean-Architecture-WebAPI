using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantDbContext dbContext) : IRestaurantRepository
    {
        public async Task<int> Create(Restaurants entity)
        {
            dbContext.Restaurants.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteRestaurantAsync(Restaurants entity)
        {
         
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Restaurants>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Restaurants>> GetAllMatchingAsync(string? searchPhrase)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var restaurants = await dbContext.Restaurants
                .Where(x => searchPhraseLower == null ||( x.Name.ToLower().Contains(searchPhraseLower) ||
                x.Description.ToLower().Contains(searchPhraseLower)))
                .ToListAsync();
            return restaurants;
        }

        public async Task<Restaurants?> GetByIdAsync(int id)
        {
            return await dbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateChanges() => dbContext.SaveChangesAsync();
        
    }
}
