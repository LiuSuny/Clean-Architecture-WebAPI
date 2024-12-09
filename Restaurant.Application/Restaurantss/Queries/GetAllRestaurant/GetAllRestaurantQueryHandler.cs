using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Common;
using Restaurant.Application.Restaurantss.Commands.CreateRestaurants;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryHandler(ILogger<GetAllRestaurantQueryHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantsRepository)
        : IRequestHandler<GetAllRestaurantQuery, PagedResult<RestaurantDto>>
    {
        public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {
            //var searchPhrase = request.SearchPhrase.ToLower();
            logger.LogInformation("Getting all restaurants");
            var (restaurants, totalCount) = await restaurantsRepository.GetAllMatchingAsync(request.SearchPhrase,
                request.PageSize, request.PageNumber, request.SortBy,
            request.SortDirection);
                              //.Where(x => x.Name.ToLower().Contains(request.SearchPhrase) ||
                              //x.Description.Contains(request.SearchPhrase));

            //var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity); //used for manual mapping

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            var result = new PagedResult<RestaurantDto>(restaurantsDtos, 
                totalCount, request.PageSize, request.PageNumber);
            return result;
        }
    }
}
