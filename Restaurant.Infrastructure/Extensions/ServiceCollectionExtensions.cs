using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistance;
using Restaurant.Infrastructure.Repositories;
using Restaurant.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Extensions
{
    public  static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RestaurantDbContext>(
                options => options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());

            services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<RestaurantDbContext>();

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantRepository, RestaurantsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

        }

    }
}
