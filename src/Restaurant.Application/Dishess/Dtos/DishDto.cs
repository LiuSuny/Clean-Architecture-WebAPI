using Restaurant.Domain.Entities;

namespace Restaurant.Application.Dishess.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }

        #region Manual mapping without automapper library
        //public static DishDto FromEntity(Dish dish)
        //{
        //    return new DishDto()
        //    {
        //        Id = dish.Id,
        //        Name = dish.Name,
        //        Description = dish.Description,
        //        Price = dish.Price,
        //        KiloCalories = dish.KiloCalories
        //    };
        //}
        #endregion
    }
}
