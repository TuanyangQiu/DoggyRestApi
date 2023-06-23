using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;

namespace DoggyRestApi.Profiles
{
    public class QueryTouristRoutesParamProfile : Profile
    {
        public QueryTouristRoutesParamProfile()
        {
            CreateMap<QueryTouristRoutesParamDTO, QueryTouristRoutesParam>();
        }
    }
}
