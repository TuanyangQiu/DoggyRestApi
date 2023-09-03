using DoggyRestApi.Database;
using DoggyRestApi.Helper;
using DoggyRestApi.Models;
using DoggyRestApi.ResourceParameter;
using Microsoft.EntityFrameworkCore;

namespace DoggyRestApi.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _appDbContext;

        public TouristRouteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddOrderAsync(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            await _appDbContext.Orders.AddAsync(order);
        }

        public void AddTouristRoute(TouristRoute touristRoute)
        {
            if (touristRoute == null)
                throw new ArgumentNullException(nameof(touristRoute));

            _appDbContext.TouristRoutes.Add(touristRoute);
        }

        public async Task AddTouristRoutePicturesAsync(Guid touristRouteId, ICollection<TouristRoutePicture> touristRoutePicture)
        {
            if (!(await IsTouristRouteExistAsync(touristRouteId)))
            {
                throw new Exception($"{nameof(touristRouteId)} is not existed in database");
            }

            if (touristRoutePicture == null || touristRoutePicture.Count <= 0)
            {
                throw new ArgumentNullException(nameof(touristRoutePicture));
            }

            foreach (var i in touristRoutePicture)
            {
                i.TouristRouteId = touristRouteId;
                _appDbContext.TouristRoutePictures.Add(i);
            }


        }

        public void CreateShoppingCart(ShoppingCart shoppingCart)
        {
            ArgumentNullException.ThrowIfNull(shoppingCart);


            _appDbContext.shoppingCarts.Add(shoppingCart);
        }


        public void DeleteTouristRoute(TouristRoute touristRoute)
        {
            if (touristRoute == null)
                throw new ArgumentNullException(nameof(touristRoute));

            _appDbContext.TouristRoutes.Remove(touristRoute);
        }

        public async Task<Order?> GetOrderByOrderId(Guid orderId)
        {
            if (orderId == Guid.Empty)
                throw new ArgumentNullException(nameof(orderId));

            return await _appDbContext.Orders.Include(o => o.OrderItems).Where(o => o.Id == orderId).FirstOrDefaultAsync();
        }

        public async Task<PagingQuery<Order>> GetOrdersByUserIdAsync(string userId, PaginationParam paginationParam)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(userId);

            if (Guid.Parse(userId) == Guid.Empty)//here will throw another exception if parse fails
                throw new ArgumentNullException("Guid cannot be all zero");

            string lowerUserId = userId.ToLower();

            var result = _appDbContext.Orders.
                                       Include(o => o.OrderItems).ThenInclude(item => item.TouristRoute).
                                       Where(o => o.OwnerId.ToLower() == lowerUserId);

            return await PagingQuery<Order>.QueryAsync(paginationParam, result);


        }

        public async Task<Order?> GetPendingOrdersByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(userId);

            if (Guid.Parse(userId) == Guid.Empty)//here will throw another exception if parse fails
                throw new ArgumentNullException("Guid cannot be all zero");

            string lowerUserId = userId.ToLower();

            var result = _appDbContext.Orders.
                                       Include(o => o.OrderItems).ThenInclude(item => item.TouristRoute).
                                       Where(o => o.OwnerId.ToLower() == lowerUserId && o.OrderStatus==OrderStatusEnum.Pending);

            return await result.FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<TouristRoutePicture>> GetPicturesByIdAsync(Guid touristRouteId)
        {
            return await _appDbContext.TouristRoutePictures.Where(
                i =>
                i.TouristRouteId.Equals(touristRouteId)).ToListAsync();
        }

        public async Task<ShoppingCart?> GetShoppingCartByIdAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);

            return await _appDbContext.shoppingCarts.
                  Include(i => i.Owner).
                  Include(i => i.LineItems).
                  Where(cart => userId.Equals(cart.OwnerId)).
                  FirstOrDefaultAsync();
        }

        public Task<TouristRoutePicture?> GetSinglePictureByIdAsync(Guid touristRouteId, int pictureId)
        {
            return _appDbContext.TouristRoutePictures.FirstOrDefaultAsync(
                i =>
                i.TouristRouteId.Equals(touristRouteId) && i.Id == pictureId);
        }

        public Task<TouristRoute?> GetTouristRouteByIdAsync(Guid touristRouteId)
        {

            return _appDbContext.TouristRoutes.
                                 Include(i => i.TouristRoutePictures).
                                 FirstOrDefaultAsync(i => i.Id.Equals(touristRouteId));
        }

        public async Task<PagingQuery<TouristRoute>> GetTouristRoutesAsync(QueryTouristRoutesParam queryParam, PaginationParam paginationParam)
        {
            IQueryable<TouristRoute> result = _appDbContext.TouristRoutes.Include(i => i.TouristRoutePictures);

            //use default parameters if input argument is null
            if (queryParam == null)
                queryParam = new QueryTouristRoutesParam();

            //Filter out tourist routes with a rating higher than the specified value
            result = result.Where(i => i.Rating >= queryParam.Rating);


            //keyword match
            if (!string.IsNullOrWhiteSpace(queryParam.Keyword))
            {
                string lowerKeyword = queryParam.Keyword.ToLower();
                result = result.Where(t => t.Title.ToLower().Contains(lowerKeyword));
            }

            return await PagingQuery<TouristRoute>.QueryAsync(paginationParam, result);
        }

        public Task<bool> IsTouristRouteExistAsync(Guid touristRouteId)
        {
            return _appDbContext.TouristRoutes.AnyAsync(i => i.Id.Equals(touristRouteId));
        }

        public async Task<bool> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync() >= 0;
        }
    }
}
