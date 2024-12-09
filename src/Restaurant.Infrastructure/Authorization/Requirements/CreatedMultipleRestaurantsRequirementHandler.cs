using Microsoft.AspNetCore.Authorization;
using Restaurant.Application.Users;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Authorization.Requirements
{
    internal class CreatedMultipleRestaurantsRequirementHandler(IRestaurantRepository restaurantsRepository,
         IUserContext userContext) : AuthorizationHandler<CreatedMultipleRestaurantsRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            CreatedMultipleRestaurantsRequirement requirement)
        {
            var currentUser = userContext.GetCurrentUser();
            var restaurants = await restaurantsRepository.GetAllAsync();
            var userRestaurantsCreated = restaurants.Count(r => r.OwnerId == currentUser!.Id);
            if (userRestaurantsCreated >= requirement.MinimumRestaurantsCreated)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
