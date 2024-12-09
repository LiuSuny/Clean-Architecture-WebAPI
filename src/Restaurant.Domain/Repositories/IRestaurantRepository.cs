using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurants>> GetAllAsync();
        Task<Restaurants?> GetByIdAsync(int id);
        Task<int> Create(Restaurants entity);
        Task DeleteRestaurantAsync(Restaurants entity);
        Task UpdateChanges();
        Task<(IEnumerable<Restaurants>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, 
            int pageNumber, string? sortBy, SortDirection sortDirection);
    }
}

