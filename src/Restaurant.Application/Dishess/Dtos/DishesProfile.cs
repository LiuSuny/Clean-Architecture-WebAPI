using AutoMapper;
using Restaurant.Application.Dishess.Commands.CreateDish;
using Restaurant.Application.Restaurantss.Dtos;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishess.Dtos
{
    internal class DishesProfile : Profile
    {
        public DishesProfile ()
        {
            CreateMap<CreateDishesCommand, Dish>();
            CreateMap<Dish, DishDto>();
                     
        }
    }
}
