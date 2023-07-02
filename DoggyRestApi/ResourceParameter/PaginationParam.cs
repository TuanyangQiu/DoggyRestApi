namespace DoggyRestApi.ResourceParameter
{
    public class PaginationParam
    {
        private int _pageNumber = 1;

        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                if (value >= 1)
                    _pageNumber = value;
            }
        }


        private const int _defaultPageSize = 5;
        private const int _maxPageSize = 20;
        private int _pageSize = _defaultPageSize;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                if (value > _maxPageSize)
                    _pageSize = _maxPageSize;
                else if (value >= 1)
                    _pageSize = value;
                else
                    _pageSize = _defaultPageSize;
            }
        }
    }
}
