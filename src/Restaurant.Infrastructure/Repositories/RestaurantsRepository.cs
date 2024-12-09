using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistance;
using Restaurant.Domain.Constants;
using System.Linq.Expressions;
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

        public async Task<(IEnumerable<Restaurants>, int)> GetAllMatchingAsync(string? searchPhrase,
            int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = dbContext.Restaurants
               //search filter
               .Where(x => searchPhraseLower == null || (x.Name.ToLower().Contains(searchPhraseLower) ||
                x.Description.ToLower().Contains(searchPhraseLower)));

               var totalCount = await baseQuery.CountAsync();
            //sorting
            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Restaurants, object>>>
            {
                { nameof(Restaurants.Name), r => r.Name },
                { nameof(Restaurants.Description), r => r.Description },
                { nameof(Restaurants.Category), r => r.Category },
            };
                var selectedColumn = columnsSelector[sortBy];
                baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

              var restaurants = await baseQuery
                    // Pagination
                    .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            return (restaurants, totalCount);
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
