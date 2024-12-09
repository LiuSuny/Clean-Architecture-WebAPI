﻿using AutoMapper;
using FluentAssertions;
using Restaurant.Application.Restaurantss.Commands.CreateRestaurants;
using Restaurant.Application.Restaurantss.Commands.UpdateRestaurant;
using Restaurant.Domain.Entities;
using Xunit;

namespace Restaurant.Application.Restaurantss.Dtos.Tests
{
    public class RestaurantProfileTests
    {
        private IMapper _mapper;
        public RestaurantProfileTests()
        {
            //config automapper dto
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<RestaurantProfile>();
            });
            _mapper = configuration.CreateMapper();
        }


        [Fact()]
        public void CreateMap_ForRestaurantToRestaurantDto_MapsCorrectly()
        {
            // arrange
            var restaurant = new Restaurants()
            {
                Id = 1,
                Name = "Test restaurant",
                Description = "Test Description",
                Category = "Test Category",
                HasDelivery = true,
                ContactEmail = "test@example.com",
                ContactNumber = "123456789",
                Address = new Address
                {
                    City = "Test City",
                    Steet = "Test Street",
                    PostalCode = "12-345"
                }
            };

            // act
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            // assert 
            restaurantDto.Should().NotBeNull();
            restaurantDto.Id.Should().Be(restaurant.Id);
            restaurantDto.Name.Should().Be(restaurant.Name);
            restaurantDto.Description.Should().Be(restaurant.Description);
            restaurantDto.Category.Should().Be(restaurant.Category);
            restaurantDto.HasDelivery.Should().Be(restaurant.HasDelivery);
            restaurantDto.City.Should().Be(restaurant.Address.City);
            restaurantDto.Steet.Should().Be(restaurant.Address.Steet);
            restaurantDto.PostalCode.Should().Be(restaurant.Address.PostalCode);
        }

        [Fact()]
        public void CreateMap_ForUpdateRestaurantCommandToRestaurant_MapsCorrectly()
        {
            // arrange
            var command = new UpdateRestaurantCommand
            {
                Id = 1,
                Name = "Updated Restaurant",
                Description = "Updated Description",
                HasDelivery = false
            };
            // act
            var restaurant = _mapper.Map<Restaurants>(command);
            // assert 
            restaurant.Should().NotBeNull();
            restaurant.Id.Should().Be(command.Id);
            restaurant.Name.Should().Be(command.Name);
            restaurant.Description.Should().Be(command.Description);
            restaurant.HasDelivery.Should().Be(command.HasDelivery);
        }

        [Fact()]
        public void CreateMap_ForCreateRestaurantCommandToRestaurant_MapsCorrectly()
        {
            // arrange
            var command = new CreateRestaurantCommand
            {
                Name = "Test Restaurant",
                Description = "Test Description",
                Category = "Test Category",
                HasDelivery = true,
                ContactEmail = "test@example.com",
                ContactNumber = "123456789",
                City = "Test City",
                Steet = "Test Street",
                PostalCode = "12345"
            };

            // act
            var restaurant = _mapper.Map<Restaurants>(command);

            // assert 
            restaurant.Should().NotBeNull();
            restaurant.Name.Should().Be(command.Name);
            restaurant.Description.Should().Be(command.Description);
            restaurant.Category.Should().Be(command.Category);
            restaurant.HasDelivery.Should().Be(command.HasDelivery);
            restaurant.ContactEmail.Should().Be(command.ContactEmail);
            restaurant.ContactNumber.Should().Be(command.ContactNumber);
            restaurant.Address.Should().NotBeNull();
            restaurant.Address.City.Should().Be(command.City);
            restaurant.Address.Steet.Should().Be(command.Steet);
            restaurant.Address.PostalCode.Should().Be(command.PostalCode);
        }
    }
}