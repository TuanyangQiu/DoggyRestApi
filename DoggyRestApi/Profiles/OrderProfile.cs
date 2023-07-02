using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;

namespace DoggyRestApi.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>().ForMember(
                dest => dest.OrderStatus,
                opt => opt.MapFrom(src => src.OrderStatus.ToString()));

            CreateMap<LineItem, OrderedItem>().ForMember(
                dest => dest.Id,
                opt => opt.Ignore());//Do NOT map id

            CreateMap<OrderedItem, OrderedItemDTO>();
        }
    }
}
