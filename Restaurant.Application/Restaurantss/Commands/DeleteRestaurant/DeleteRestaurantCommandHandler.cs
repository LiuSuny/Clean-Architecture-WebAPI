using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurantss.Commands.CreateRestaurants;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
         IRestaurantRepository restaurantsRepository)
        : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with id {@RestaurantId}", request.Id);
            var restaurants = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurants is null)
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            await restaurantsRepository.DeleteRestaurantAsync(restaurants);

            //var restaurantDto = RestaurantDto.FromEntity(restaurants); //used for manual mapping

            //var restaurantDto = mapper.Map<RestaurantDto>(restaurants);
            //return true;
        }
    }
}
