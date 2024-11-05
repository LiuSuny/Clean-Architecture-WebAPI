using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurantss.Commands.CreateRestaurants;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantsRepository)
        : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting restaurant with id {request.Id}");
            var restaurants = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurants is null)
                return false;

            await restaurantsRepository.DeleteRestaurantAsync(restaurants);

            //var restaurantDto = RestaurantDto.FromEntity(restaurants); //used for manual mapping

            //var restaurantDto = mapper.Map<RestaurantDto>(restaurants);
            return true;
        }
    }
}
