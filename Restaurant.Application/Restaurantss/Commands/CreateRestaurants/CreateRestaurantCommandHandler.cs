using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Commands.CreateRestaurants
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {

       
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new restaurant");
            var restaurant = mapper.Map<Restaurants>(request);
            int id = await restaurantsRepository.Create(restaurant);
            return id;
        }
    }
}
