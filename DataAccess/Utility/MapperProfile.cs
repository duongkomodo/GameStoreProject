using AutoMapper;
using BusinessObject.Models;
using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utility
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Game, DisplayGameDto>()
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.Price.ToString("#,##0đ")))
                .ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount.ToString("0%")))
                .ForMember(dest => dest.SalePrice, act => act.MapFrom(src => (src.Price - (src.Price * src.Discount)/100).ToString("#,##0đ")));
            CreateMap<Category, CategoryDto>().ReverseMap();

        }

        protected internal MapperProfile(string profileName) : base(profileName)
        {
        }

    }
}