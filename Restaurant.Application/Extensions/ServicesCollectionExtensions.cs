using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Restaurantss;


namespace Restaurant.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IRestaurantsService, RestaurantsService>();
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var applicationAssembly = typeof(ServicesCollectionExtensions).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));

            services.AddAutoMapper(applicationAssembly);


            services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
        }
    }
}
