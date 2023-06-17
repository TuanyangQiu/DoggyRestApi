using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;

namespace DoggyRestApi.Profiles
{
    public class TouristRouteProfile : Profile
    {

        public TouristRouteProfile()
        {
            CreateMap<TouristRoute, TouristRouteDTO>().
                ForMember(
                dst => dst.Price,
                opt => opt.MapFrom(src => src.OriginalPrice * (decimal)((src.DiscountPercent == null || src.DiscountPercent == 0) ? 1 : src.DiscountPercent))).
                ForMember(
                dst => dst.TravelDays,
                opt => opt.MapFrom(src => src.TravelDays.ToString())).
                ForMember(
                dst => dst.TripType,
                opt => opt.MapFrom(src => src.TripType.ToString())).
                ForMember(
                dst => dst.DepartureCity,
                opt => opt.MapFrom(src => src.DepartureCity.ToString()));


            CreateMap<NewTouristRouteDTO, TouristRoute>().
                ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())).
                ForMember(dest => dest.CreateTime,
                opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateTouristRouteDTO, TouristRoute>().
                ForMember(dest => dest.UpdateTime,
                opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<TouristRoute, UpdateTouristRouteDTO>();
        }
    }
}
