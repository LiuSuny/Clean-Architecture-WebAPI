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

namespace Restaurant.Application.Restaurantss.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryHandler(ILogger<GetAllRestaurantQueryHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantsRepository)
        : IRequestHandler<GetAllRestaurantQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {
            //var searchPhrase = request.SearchPhrase.ToLower();
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllMatchingAsync(request.SearchPhrase);
                              //.Where(x => x.Name.ToLower().Contains(request.SearchPhrase) ||
                              //x.Description.Contains(request.SearchPhrase));

            //var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity); //used for manual mapping

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }
    }
}
