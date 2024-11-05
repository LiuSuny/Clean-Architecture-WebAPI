using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurants>> GetAllAsync();
        Task<Restaurants?> GetByIdAsync(int id);
        Task<int> Create(Restaurants entity);
        Task DeleteRestaurantAsync(Restaurants entity);
        Task UpdateChanges();
    }
}

