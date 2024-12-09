using MediatR;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishess.Commands.DeleteDishes
{
    public class DeleteDishesCommand (int restaurantId) : IRequest
    {
        public int RestaurantId { get; set; } = restaurantId; //for the header since we alreaady pass the body

    }
}
