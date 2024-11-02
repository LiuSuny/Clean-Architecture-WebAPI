using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;


namespace Restaurant.Application.Restaurantss
{
    internal class RestaurantsService(IRestaurantRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();

            var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity);

            return restaurantsDtos!;
            
        }

        public async  Task<RestaurantDto?> GetByIdRestaurants(int id)
        {
            logger.LogInformation("Get restaurants by id");
            var restaurants = await restaurantsRepository.GetByIdAsync(id);
            var restaurantDto = RestaurantDto.FromEntity(restaurants);
            return restaurantDto;
        }
    }
}
