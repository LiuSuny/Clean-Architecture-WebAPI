using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain
{
    public class User : IdentityUser
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }

        public List<Restaurants> OwnedRestaurants { get; set; } = [];
    }
}
