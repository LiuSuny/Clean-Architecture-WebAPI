

using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Persistance;

namespace Restaurant.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            //check first if we can able to connect to db
            if(await dbContext.Database.CanConnectAsync())
            {
                //check if there no any data in our restaurants table
                if(!dbContext.Restaurants.Any())
                {
                    var restaurant = GetRestaurants();
                     dbContext.AddRange(restaurant);
                    await dbContext.SaveChangesAsync();
                }

            }
        }

        private IEnumerable<Restaurants> GetRestaurants()
        {
            List<Restaurants> restaurants = [
           new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description =
                    "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,

                Dishes =
                [
                    new ()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10 pcs.)",
                        Price = 10.30M,
                    },
                    new ()
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets (5 pcs.)",
                        Price = 5.30M,
                    },
                ],
                Address = new ()
                {
                    City = "London",
                    Steet = "Cork St 5",
                    PostalCode = "WC2N 5DU"
                }
            },
            new ()
            {
                Name = "McDonald",
                Category = "Fast Food",
                Description =
                    "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                ContactEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Address = new Address()
                {
                    City = "London",
                    Steet = "Boots 193",
                    PostalCode = "W1F 8SR"
                }
            }
       ];
            return restaurants;
        }
    }
}
