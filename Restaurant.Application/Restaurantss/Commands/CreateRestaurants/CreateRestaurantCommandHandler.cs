﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Users;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Commands.CreateRestaurants
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantRepository restaurantsRepository,
    IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
    {

       
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            //logger.LogInformation("Creating a new restaurant {@Restaurant}", request);
            var currentUser = userContext.GetCurrentUser();
            logger.LogInformation("{UserEmail} [{UserId}] is creating a new restaurant {@Restaurant}",
                currentUser.Email,
                currentUser.Id,
                request);
            var restaurant = mapper.Map<Restaurants>(request);
            restaurant.OwnerId = currentUser.Id;
            int id = await restaurantsRepository.Create(restaurant);
            return id;
        }
    }
}
