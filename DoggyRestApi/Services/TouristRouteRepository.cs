using DoggyRestApi.Database;
using DoggyRestApi.Models;
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

        public Task<TouristRoutePicture?> GetSinglePictureByIdAsync(Guid touristRouteId, int pictureId)
        {
            return _appDbContext.TouristRoutePictures.FirstOrDefaultAsync(
                i =>
                i.TouristRouteId.Equals(touristRouteId) && i.Id == pictureId);
        }

        public Task<TouristRoute?> GetTouristRouteByIdAsync(Guid touristRouteId)
        {
            return _appDbContext.TouristRoutes.Include(i => i.TouristRoutePictures).FirstOrDefaultAsync(i => i.Id.Equals(touristRouteId));
        }

        public async Task<IEnumerable<TouristRoute>?> GetTouristRoutesAsync(string? keyword, string? operation, int? score)
        {
            IQueryable<TouristRoute> result = _appDbContext.TouristRoutes.Include(i => i.TouristRoutePictures);


            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(i => i.Title.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(operation) && score > 0)
            {
                result = operation.ToLower() switch
                {
                    "largerthan" => result.Where(i => i.Rating > score),
                    "lessthan" => result.Where(i => i.Rating < score),
                    _ => result.Where(i => i.Rating == score),
                };
            }

            return await result.ToListAsync();
        }

        public Task<bool> IsTouristRouteExistAsync(Guid touristRouteId)
        {
            return _appDbContext.TouristRoutes.AnyAsync(i => i.Id.Equals(touristRouteId));
        }

        public bool Save()
        {
            int iRet = _appDbContext.SaveChanges();
            return iRet >= 0;
        }
    }
}
