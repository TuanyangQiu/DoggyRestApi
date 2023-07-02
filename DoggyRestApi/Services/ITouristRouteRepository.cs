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

        public Task AddTouristRoutePicturesAsync(Guid touristRouteId, ICollection<TouristRoutePicture> touristRoutePicture);


        public void DeleteTouristRoute(TouristRoute touristRoute);

        public void CreateShoppingCart(ShoppingCart shoppingCart);

        public Task<ShoppingCart?> GetShoppingCartByIdAsync(string userId);

        public Task AddOrderAsync(Order order);

        public Task<List<Order>?> GetOrdersByUserIdAsync(string userId);

        public Task<Order?> GetOrderByOrderId(Guid orderId);
    }
}
