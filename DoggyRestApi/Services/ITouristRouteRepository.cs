using DoggyRestApi.DTOs;
using DoggyRestApi.Models;

namespace DoggyRestApi.Services
{
    public interface ITouristRouteRepository
    {
        public Task<IEnumerable<TouristRoute>?> GetTouristRoutesAsync(QueryTouristRoutesParam? parameters);

        public Task<TouristRoute?> GetTouristRouteByIdAsync(Guid touristRouteId);

        public Task<IEnumerable<TouristRoutePicture>> GetPicturesByIdAsync(Guid touristRouteId);

        public Task<bool> IsTouristRouteExistAsync(Guid touristRouteId);

        public Task<TouristRoutePicture?> GetSinglePictureByIdAsync(Guid touristRouteId, int pictureId);

        public void AddTouristRoute(TouristRoute touristRoute);

        public Task<bool> SaveAsync();

        public Task AddTouristRoutePictures(Guid touristRouteId, ICollection<TouristRoutePicture> touristRoutePicture);


        public void DeleteTouristRoute(TouristRoute touristRoute);
    }
}
