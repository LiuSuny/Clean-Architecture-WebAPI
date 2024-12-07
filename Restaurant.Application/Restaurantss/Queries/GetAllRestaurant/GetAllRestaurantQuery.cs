using MediatR;
using Restaurant.Application.Restaurantss.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQuery : IRequest<IEnumerable<RestaurantDto>>
    {
        public string? SearchPhrase { get; set; }

    }
}
