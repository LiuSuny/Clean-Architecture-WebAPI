using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Restaurantss;
using Restaurant.Application.Restaurantss.Dtos;
using System.Reflection.Metadata.Ecma335;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {
      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsService.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetbyId([FromRoute]int id)
        {
            var restaurants = await restaurantsService.GetByIdRestaurants(id);
            if (restaurants == null) return NotFound();
            return Ok(restaurants);


        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            int id = await restaurantsService.Create(createRestaurantDto);
            return CreatedAtAction(nameof(GetbyId), new { id }, null);
        }
    }
}
