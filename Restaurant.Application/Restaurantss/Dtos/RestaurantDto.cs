using Restaurant.Application.Dish.Dtos;
using Restaurant.Domain.Entities;


namespace Restaurant.Application.Restaurantss.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string City { get; set; } = default!;
        public string Steet { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public List<DishDto> Dishes { get; set; } = [];


        public static RestaurantDto? FromEntity(Restaurants? restaurant)
        {
            if (restaurant == null) return null;
            return new RestaurantDto()
            {
                Category = restaurant.Category,
                Description = restaurant.Description,
                Id = restaurant.Id,
                HasDelivery = restaurant.HasDelivery,
                Name = restaurant.Name,
                City = restaurant.Address?.City,
                Steet = restaurant.Address?.Steet,
                PostalCode = restaurant.Address?.PostalCode,

                Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()
            };
        }
    }
}
