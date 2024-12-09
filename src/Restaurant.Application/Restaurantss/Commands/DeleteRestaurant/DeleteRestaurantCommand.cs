using MediatR;
using Restaurant.Application.Restaurantss.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand(int id) : IRequest //IRequest--just this command b/c we don't want to return anything after deleting
    {
        public int Id { get; set; } = id; //for the header since we alreaady pass the body

    }
}
