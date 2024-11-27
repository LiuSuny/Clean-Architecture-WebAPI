using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurantss.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantsRepository, IRestaurantAuthorizationService restaurantAuthorizationService)
        : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating restaurant with id: {@RestaurantId} with {@UpdatedRestaurant}",
                request.Id, request);
            var restaurants = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurants is null)
                  throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            if (!restaurantAuthorizationService.Authorize(restaurants, ResourceOperation.Update))
                throw new ForbidException();

            mapper.Map(request, restaurants);
            //restaurant.Name = request.Name;
            //restaurant.Description = request.Description;
            //restaurant.HasDelivery = request.HasDelivery;
            await restaurantsRepository.UpdateChanges();
            

        }
    }
}
