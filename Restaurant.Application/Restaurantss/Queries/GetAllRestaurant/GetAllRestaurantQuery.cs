using MediatR;
using Restaurant.Application.Common;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQuery : IRequest<PagedResult<RestaurantDto>>
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

    }
}
