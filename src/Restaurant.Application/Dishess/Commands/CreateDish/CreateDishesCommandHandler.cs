using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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

namespace Restaurant.Application.Dishess.Commands.CreateDish
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
      IRestaurantRepository restaurantsRepository,
      IDishesRepository dishesRepository,
      IMapper mapper, IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<CreateDishesCommand, int>
    {
        public async Task<int> Handle(CreateDishesCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish: {@DishRequest}", request);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) 
                throw new NotFoundException(nameof(Restaurants), request.RestaurantId.ToString());
            if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
                throw new ForbidException();
            var dish = mapper.Map<Dish>(request);
            return await dishesRepository.Create(dish);
        }
    }
}
