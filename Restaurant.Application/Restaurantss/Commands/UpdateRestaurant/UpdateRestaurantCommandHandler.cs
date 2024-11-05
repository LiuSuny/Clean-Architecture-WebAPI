using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurantss.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantsRepository)
        : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating restaurant with id: {@RestaurantId} with {@UpdatedRestaurant}",
                request.Id, request);
            var restaurants = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurants is null)
                  throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            mapper.Map(request, restaurants);
            //restaurant.Name = request.Name;
            //restaurant.Description = request.Description;
            //restaurant.HasDelivery = request.HasDelivery;
            await restaurantsRepository.UpdateChanges();
            

        }
    }
}
