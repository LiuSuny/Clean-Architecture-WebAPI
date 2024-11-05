using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;


namespace Restaurant.Application.Restaurantss
{
    internal class RestaurantsService(IRestaurantRepository restaurantsRepository,
    ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        #region Using Mediatr instead of service class

        //public async Task<int> Create(CreateRestaurantDto dto)
        //{
        //    logger.LogInformation("Creating a new restaurant");
        //    var restaurant = mapper.Map<Restaurants>(dto);
        //    int id = await restaurantsRepository.Create(restaurant);
        //    return id;
        //}


        //public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        //{
        //    logger.LogInformation("Getting all restaurants");
        //    var restaurants = await restaurantsRepository.GetAllAsync();

        //    //var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity); //used for manual mapping

        //    var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        //    return restaurantsDtos;

        //}

        //public async  Task<RestaurantDto> GetByIdRestaurants(int id)
        //{
        //    logger.LogInformation($"Getting restaurant {id}");
        //    var restaurants = await restaurantsRepository.GetByIdAsync(id);

        //    //var restaurantDto = RestaurantDto.FromEntity(restaurants); //used for manual mapping

        //    var restaurantDto = mapper.Map<RestaurantDto>(restaurants);
        //    return restaurantDto;
        //} 
        #endregion
    }
}
