using DoggyRestApi.Models;

namespace DoggyRestApi.Services
{
    public interface ITouristRouteRepository
    {
        public Task<IEnumerable<TouristRoute>?> GetTouristRoutesAsync(string? keyword, string? operation, int? score);

        public Task<TouristRoute?> GetTouristRouteByIdAsync(Guid touristRouteId);

        public Task<IEnumerable<TouristRoutePicture>> GetPicturesByIdAsync(Guid touristRouteId);

        public Task<bool> IsTouristRouteExistAsync(Guid touristRouteId);

        public Task<TouristRoutePicture?> GetSinglePictureByIdAsync(Guid touristRouteId, int pictureId);

        public void AddTouristRoute(TouristRoute touristRoute);

        public bool Save();

        public Task AddTouristRoutePictures(Guid touristRouteId, ICollection<TouristRoutePicture> touristRoutePicture);


        public void DeleteTouristRoute(TouristRoute touristRoute);
    }
}
