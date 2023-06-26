using DoggyRestApi.Database;
using DoggyRestApi.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DoggyRestApi.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _appDbContext;

        public TouristRouteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddTouristRoute(TouristRoute touristRoute)
        {
            if (touristRoute == null)
                throw new ArgumentNullException(nameof(touristRoute));

            _appDbContext.TouristRoutes.Add(touristRoute);
        }

        public async Task AddTouristRoutePictures(Guid touristRouteId, ICollection<TouristRoutePicture> touristRoutePicture)
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

        public async Task<IEnumerable<TouristRoutePicture>> GetPicturesByIdAsync(Guid touristRouteId)
        {
            return await _appDbContext.TouristRoutePictures.Where(
                i =>
                i.TouristRouteId.Equals(touristRouteId)).ToListAsync();
        }

        public async Task<ShoppingCart?> GetShoppingCartById(string userId)
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

        public async Task<IEnumerable<TouristRoute>?> GetTouristRoutesAsync(QueryTouristRoutesParam? parameters)
        {
            //没有条件，不应该全部返回！待完善！！！
            IQueryable<TouristRoute> result = _appDbContext.TouristRoutes.Include(i => i.TouristRoutePictures);
            if (parameters == null)
                return await result.Take(5).ToListAsync();

            //Filter out tourist routes with a rating higher than the specified value
            if (parameters.Rating > 0)
                result = result.Where(i => i.Rating >= parameters.Rating);

            //Filter out tourist routes that match the specified id
            if (parameters.Id?.Count > 0)
                result = result.Where(i => parameters.Id.Any(j => j.Equals(i.Id)));

            //keyword match
            if (!string.IsNullOrWhiteSpace(parameters.Keyword))
                result = result.Where(t => t.Title.ToLower().Contains(parameters.Keyword.ToLower()));



            ////Find out tourist routes whose Title or Description contain these keywords
            //if (parameters.Keywords != null)
            //{
            //    result = result.Select(touristRoute =>
            //    new
            //    {
            //        matchedTouristRoute = touristRoute,
            //        matchedCount = parameters.Keywords.Count(
            //          kw => touristRoute.Title.Contains(kw) || touristRoute.Description.Contains(kw))
            //    }).
            //    //filter out unmatched tourist routes
            //    Where(item => item.matchedCount > 0).
            //    //The more matches of keywords a tourist route has, the higher its ranked
            //    OrderByDescending(matchedItem => matchedItem.matchedCount).
            //    Select(matchedItem => matchedItem.matchedTouristRoute);
            //}

            return await result.ToListAsync();
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
