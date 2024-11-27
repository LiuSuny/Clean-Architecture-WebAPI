using FluentAssertions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Authorization;
using Restaurant.Infrastructure.Authorization.Constants;
using Restaurant.Infrastructure.Authorization.Requirements;
using Restaurant.Infrastructure.Authorization.Services;
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
                 .AddRoles<IdentityRole>().
                 AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<RestaurantDbContext>();

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantRepository, RestaurantsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();
            services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.HasNationality,
                builder => builder.RequireClaim(AppClaimTypes.Nationality, "German", "Polish"))
            .AddPolicy(PolicyNames.AtLeast20,
               builder => builder.AddRequirements(new MinimumAgeRequirement(20)))
            .AddPolicy(PolicyNames.CreatedAtleast2Restaurants,
                builder => builder.AddRequirements(new CreatedMultipleRestaurantsRequirement(2)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, CreatedMultipleRestaurantsRequirementHandler>();
            services.AddScoped<IRestaurantAuthorizationService, RestaurantAuthorizationService>();
        }

    }
}
