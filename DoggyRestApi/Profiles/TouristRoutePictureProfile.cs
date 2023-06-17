using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;

namespace DoggyRestApi.Profiles
{
    public class TouristRoutePictureProfile : Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePictureDTO>();

            CreateMap<NewTouristRoutePictureDTO, TouristRoutePicture>().
                ForMember(dest => dest.Url,
                option => option.MapFrom(src => "../../assets/images/" + src.PictureName)
                );

            CreateMap<TouristRoutePicture, NewTouristRoutePictureDTO>().
                ForMember(dest => dest.PictureName,
                opt => opt.MapFrom(src => ChangePictureName(src.Url)));
        }

        private string ChangePictureName(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            return url.Split('/').Last();
        }

    }
}
