using AutoMapper;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Dtos
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<CreateRestaurantDto, Restaurants>()
            .ForMember(d => d.Address, opt => opt.MapFrom(
                src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Steet = src.Steet
                }));


            CreateMap<Restaurants, RestaurantDto>()
                   .ForMember(d => d.City, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.PostalCode, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Steet, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.Steet))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
        }
    }
}
