﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Restaurantss;
using Restaurant.Application.Restaurantss.Commands.CreateRestaurants;
using Restaurant.Application.Restaurantss.Commands.DeleteRestaurant;
using Restaurant.Application.Restaurantss.Commands.UpdateRestaurant;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Application.Restaurantss.Queries.GetAllRestaurant;
using Restaurant.Application.Restaurantss.Queries.GetRestaurantById;
using System.Reflection.Metadata.Ecma335;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(/*IRestaurantsService restaurantsService*/ IMediator mediatr) : ControllerBase
    {
      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var restaurants = await restaurantsService.GetAllRestaurants();
            var restaurants = await mediatr.Send( new GetAllRestaurantQuery());

            return Ok(restaurants);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetbyId([FromRoute]int id)
        {
            // var restaurants = await restaurantsService.GetByIdRestaurants(id);
            var restaurants = await mediatr.Send(new GetRestaurantByIdQuery(id));
            //{
            //    Id = id
            //});

            if (restaurants == null) return NotFound();
            return Ok(restaurants);


        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            // int id = await restaurantsService.Create(createRestaurantDto);
            int id = await mediatr.Send(command);
            return CreatedAtAction(nameof(GetbyId), new { id }, null);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
         
            var isDeleted = await mediatr.Send(new DeleteRestaurantCommand(id));
          
            if (isDeleted) return NoContent();
            return NotFound();


        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand command)
        {
            command.Id = id; //UpdateRestaurantCommand is equal to this route id 
            var isUpdated = await mediatr.Send(command);

            if (isUpdated) return NoContent();
            return NotFound();


        }
    }
}
