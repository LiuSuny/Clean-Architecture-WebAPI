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

namespace Restaurant.Application.Restaurantss.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantsRepository)
        : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {

        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting restaurant {@RestaurantId}", request.Id);
            var restaurants = await restaurantsRepository.GetByIdAsync(request.Id)
                 ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            //var restaurantDto = RestaurantDto.FromEntity(restaurants); //used for manual mapping

            var restaurantDto = mapper.Map<RestaurantDto>(restaurants);
            return restaurantDto;
        }
    }
}
