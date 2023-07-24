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
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id.ToString()));
            CreateMap<Game, DisplayGameDto>()
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.Price))
                .ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount))
                .ForMember(dest => dest.SalePrice, act => act.MapFrom(src => (src.Price - (src.Price * src.Discount) / 100)));
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status  == OrderStatus.Unpaid ? OrderStatus.UnpaidText : src.Status == OrderStatus.Pending ? OrderStatus.PendingText : OrderStatus.PaidText));
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<GameKey, GameKeyDto>();
            CreateMap<UserCart, UserCartDto>().ReverseMap();

        }

        protected internal MapperProfile(string profileName) : base(profileName)
        {
        }

    }
}