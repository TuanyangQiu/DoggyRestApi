namespace DoggyRestApi.Models
{
    public class QueryTouristRoutesParam
    {
        public string? Keyword { get; set; }



        private const int _maxRating = 5;
        private const int _defaultRating = 0;
        private int _rating = _defaultRating;


        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if (value >= 0 && value <= _maxRating)
                    _rating = value;
                else
                    _rating = _defaultRating;
            }
        }

        public List<Guid>? Id { get; set; }


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
