using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace DoggyRestApi.Helper
{
    /// <summary>
    /// Get the pagination information and related page url to make APIs discoverable 
    /// </summary>
    public class PaginationUrlHelper
    {
        private readonly IUrlHelper _urlHelper;
        private readonly string _apiName;
        private readonly PaginationInfo _pageInfo;
        private readonly object? _queryParamObj;
        public PaginationUrlHelper(IUrlHelper urlHelper, string apiName, PaginationInfo pageInfo, object? queryParamObj)
        {
            _urlHelper = urlHelper;
            _apiName = apiName;
            _pageInfo = pageInfo;
            _queryParamObj = queryParamObj;
        }

        public string GetPaginationResponseHeader()
        {
            var header = new
            {
                PreviousPageUrl = GetPreviousPageUrl(),
                NextPageUrl = GetNextPageUrl(),
                PageInfo = _pageInfo
            };

            return JsonConvert.SerializeObject(header);
        }

        private string? GetPreviousPageUrl()
        {
            if (!_pageInfo.HasPreviousPage)
                return null;

            var obj = CreateObject(_pageInfo.CurrentPageNum - 1, _pageInfo.PageSize, _queryParamObj);

            return _urlHelper.Link(_apiName, obj);
        }


        private string? GetNextPageUrl()
        {
            if (!_pageInfo.HasNextPage)
                return null;

            var obj = CreateObject(_pageInfo.CurrentPageNum + 1, _pageInfo.PageSize, _queryParamObj);

            return _urlHelper.Link(_apiName, obj);
        }


        private object? CreateObject(int PageNum, int pageSize, object? queryParamObj)
        {
            Dictionary<string, object?> Dict = new Dictionary<string, object?>();
            Dict.Add("PageNumber", PageNum);
            Dict.Add("PageSize", pageSize);

            /*
            Query parameter may be added or removed in the future,
            so, I use reflection to get parameters to decouple code and avoid change 
            */
            if (queryParamObj != null)
            {
                foreach (var p in queryParamObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!Dict.ContainsKey(p.Name))
                        Dict.Add(p.Name, p.GetValue(queryParamObj));
                }
            }

            return Dict;
        }

    }
}
