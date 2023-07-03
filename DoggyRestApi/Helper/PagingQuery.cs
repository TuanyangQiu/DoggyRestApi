using DoggyRestApi.ResourceParameter;
using Microsoft.EntityFrameworkCore;

namespace DoggyRestApi.Helper
{
    public class PagingQuery<T>
    {
        public List<T> DataList { get; }

        public PaginationInfo PaginationInfo { get; }

        public PagingQuery(List<T> dataList, PaginationInfo paginationInfo)
        {
            DataList = dataList;
            PaginationInfo = paginationInfo;
        }

        public static async Task<PagingQuery<T>> QueryAsync(PaginationParam? paginationParam, IQueryable<T> queryExpression)
        {

            //use default parameters if paginationParam is null
            if (paginationParam == null)
                paginationParam = new PaginationParam();

            //paging query
            int skip = (paginationParam.PageNumber - 1) * paginationParam.PageSize;
            List<T> queriedData = await queryExpression.Skip(skip).Take(paginationParam.PageSize).ToListAsync();
            int totalRecordCounts = await queryExpression.CountAsync();

            PaginationInfo pages = new PaginationInfo(totalRecordCounts: totalRecordCounts,
                                                      currentPageNum: paginationParam.PageNumber,
                                                      pageSize: paginationParam.PageSize);

            return new PagingQuery<T>(queriedData, pages);
        }
    }


    public class PaginationInfo
    {
        public PaginationInfo(int totalRecordCounts, int currentPageNum, int pageSize)
        {
            TotalRecordCounts = totalRecordCounts;

            CurrentPageNum = currentPageNum;

            PageSize = pageSize;

            TotalPageCounts = (int)Math.Ceiling(TotalRecordCounts / (double)PageSize);

            HasPreviousPage = (CurrentPageNum > 1) ? true : false;

            HasNextPage = (currentPageNum < TotalPageCounts) ? true : false;
        }

        public int TotalRecordCounts { get; }

        public int CurrentPageNum { get; }

        public int PageSize { get; }

        public int TotalPageCounts { get; }

        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
    }
}
