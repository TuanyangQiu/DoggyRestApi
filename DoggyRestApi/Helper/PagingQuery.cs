using DoggyRestApi.ResourceParameter;
using Microsoft.EntityFrameworkCore;

namespace DoggyRestApi.Helper
{
    public class PagingQuery<T>
    {
        public static async Task<List<T>?> QueryAsync(PaginationParam? paginationParam, IQueryable<T> data)
        {
            if (data == null)
                return null;

            //use default parameters if paginationParam is null
            if (paginationParam == null)
                paginationParam = new PaginationParam();

            //paging query
            int skip = (paginationParam.PageNumber - 1) * paginationParam.PageSize;
            return await data.Skip(skip).Take(paginationParam.PageSize).ToListAsync();
        }
    }
}
