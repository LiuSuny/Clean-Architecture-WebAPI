using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurantss.Commands.DeleteRestaurant;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishess.Commands.DeleteDishes
{
    public class DeleteDishesCommandHandler(ILogger<DeleteDishesCommandHandler> logger,
         IRestaurantRepository restaurantsRepository,
         IDishesRepository dishRepository, IMapper mapper, IRestaurantAuthorizationService restaurantAuthorizationService)
        : IRequestHandler<DeleteDishesCommand>
    {
        public async Task Handle(DeleteDishesCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);
            var restaurants = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurants is null)
                throw new NotFoundException(nameof(Restaurants), request.RestaurantId.ToString());

            if (!restaurantAuthorizationService.Authorize(restaurants, ResourceOperation.Update))
                throw new ForbidException();

            await dishRepository.DeleteDishAsync(restaurants.Dishes);
        }
    }
}
