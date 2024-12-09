using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repositories
{
    public interface IDishesRepository
    {
        //Task<IEnumerable<Restaurants>> GetAllAsync();
       // Task<Restaurants?> GetByIdAsync(int id);
        Task<int> Create(Dish entity);
        Task DeleteDishAsync(IEnumerable<Dish> entity);
        //Task UpdateChanges();
    }
}

