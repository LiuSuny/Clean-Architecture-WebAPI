using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Restaurantss;
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
        public async Task<IActionResult> GetAll([FromRoute]int id)
        {
            var restaurants = await restaurantsService.GetByIdRestaurants(id);
            if (restaurants == null) return NotFound();
            return Ok(restaurants);


        }
    }
}
