using MediatR;
using Restaurant.Application.Restaurantss.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto?>
    {
        //public GetRestaurantByIdQuery(int id)
        //{
        //    Id = id;
        //}
        public int Id { get; set; } = id; //for the header since we alreaady pass the body
    }
}
