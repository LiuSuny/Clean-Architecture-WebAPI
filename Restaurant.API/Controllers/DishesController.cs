using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Dishess.Commands.CreateDish;
using Restaurant.Application.Dishess.Commands.DeleteDishes;
using Restaurant.Application.Dishess.Dtos;
using Restaurant.Application.Dishess.Queries.GetAllDishesForRestaurant;
using Restaurant.Application.Dishess.Queries.GetDishByIdForRestaurant;
using Restaurant.Domain.Entities;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/restaurants/{restaurantId}/dishes")]
    public class DishesController( IMediator mediatr) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishesCommand command)
        {
            command.RestaurantId = restaurantId;
            var dishId = await mediatr.Send(command);
            return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId, dishId }, null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediatr.Send(new GetAllDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediatr.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }




        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDishes([FromRoute] int restaurantId)
        {
            await mediatr.Send(new DeleteDishesCommand(restaurantId));

            return NoContent();

        }


    }
}
