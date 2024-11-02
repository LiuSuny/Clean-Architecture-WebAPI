using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Restaurantss;


namespace Restaurant.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantsService, RestaurantsService>();

        }
    }
}
