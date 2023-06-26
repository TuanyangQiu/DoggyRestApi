using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;

namespace DoggyRestApi.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDTO>();

            CreateMap<LineItem,LineItemDTO>();  
        }
    }
}
