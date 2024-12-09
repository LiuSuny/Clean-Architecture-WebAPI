﻿using Xunit;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Application.Users;
using FluentAssertions;
using Moq;
using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Authorization.Requirements.Tests
{
    public class CreatedMultipleRestaurantsRequirementHandlerTests
    {

        [Fact()]
        public async Task HandleRequirementAsync_UserHasNotCreatedMultipleRestaurants_ShouldFail()
        {
            // arrange
            var currentUser = new CurrentUser("1", "test@test.com", [], null, null);
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(m => m.GetCurrentUser()).Returns(currentUser);
            var restaurants = new List<Restaurants>()
            {
                new()
                {
                    OwnerId = currentUser.Id,
                },
                new()
                {
                    OwnerId = "2",
                },
            };
            var restaurantsRepositoryMock = new Mock<IRestaurantRepository>();
            restaurantsRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(restaurants);
            var requirement = new CreatedMultipleRestaurantsRequirement(2);
            var handler = new CreatedMultipleRestaurantsRequirementHandler(restaurantsRepositoryMock.Object,
                userContextMock.Object);
            var context = new AuthorizationHandlerContext([requirement], null, null);

            // act
            await handler.HandleAsync(context);

            // assert
            context.HasSucceeded.Should().BeFalse();
            context.HasFailed.Should().BeTrue();
        }

        [Fact()]
        public async Task HandleRequirementAsync_UserHasCreatedMultipleRestaurants_ShouldSucceed()
        {
            // arrange
            var currentUser = new CurrentUser("1", "test@test.com", [], null, null);
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(m => m.GetCurrentUser()).Returns(currentUser);
            var restaurants = new List<Restaurants>()
            {
                new()
                {
                    OwnerId = currentUser.Id,
                },
                new()
                {
                    OwnerId = currentUser.Id,
                },
                new()
                {
                    OwnerId = "2",
                },
            };
            var restaurantsRepositoryMock = new Mock<IRestaurantRepository>();
            restaurantsRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(restaurants);
            var requirement = new CreatedMultipleRestaurantsRequirement(2);
            var handler = new CreatedMultipleRestaurantsRequirementHandler(restaurantsRepositoryMock.Object,
                userContextMock.Object);
            var context = new AuthorizationHandlerContext([requirement], null, null);
            // act
            await handler.HandleAsync(context);

            // assert

            context.HasSucceeded.Should().BeTrue();
        }
    }
}