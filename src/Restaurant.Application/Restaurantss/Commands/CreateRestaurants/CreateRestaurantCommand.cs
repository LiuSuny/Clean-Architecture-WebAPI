using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Commands.CreateRestaurants
{
    //Create command CQRS Mediatr
    public class CreateRestaurantCommand : IRequest<int>
    {
        
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? City { get; set; }
        public string? Steet { get; set; }
        public string? PostalCode { get; set; }
    }
}
