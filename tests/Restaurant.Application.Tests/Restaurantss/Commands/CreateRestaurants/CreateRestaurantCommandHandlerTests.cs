﻿using Xunit;
using Restaurant.Application.Restaurantss.Commands.CreateRestaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Restaurant.Application.Users;
using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Restaurantss.Commands.CreateRestaurants.Tests
{
    public class CreateRestaurantCommandHandlerTests
    {
        [Fact()]
        public async Task Handle_ForValidCommand_ReturnsCreatedRestaurantId()
        {
            // arrange
            var loggerMock = new Mock<ILogger<CreateRestaurantCommandHandler>>();

            var mapperMock = new Mock<IMapper>();

            var command = new CreateRestaurantCommand();

            var restaurant = new Restaurants();

            mapperMock.Setup(m => m.Map<Restaurants>(command)).Returns(restaurant);

            var restaurantRepositoryMock = new Mock<IRestaurantRepository>();

            restaurantRepositoryMock
                .Setup(repo => repo.Create(It.IsAny<Restaurants>()))
                .ReturnsAsync(1);

            var userContextMock = new Mock<IUserContext>();

            var currentUser = new CurrentUser("owner-id", "test@test.com", [], null, null);
            userContextMock.Setup(u => u.GetCurrentUser()).Returns(currentUser);

            var commandHandler = new CreateRestaurantCommandHandler(loggerMock.Object,
                mapperMock.Object,
                restaurantRepositoryMock.Object,
                userContextMock.Object);

            // act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // assert
            result.Should().Be(1);
            restaurant.OwnerId.Should().Be("owner-id");
            restaurantRepositoryMock.Verify(r => r.Create(restaurant), Times.Once);
        }
    }
}