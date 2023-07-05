namespace DoggyRestApi.ResourceParameter
{
    public class QueryTouristRoutesParam
    {
        /// <summary>
        /// match keyword in the title of tourist routes
        /// </summary>
        public string? Keyword { get; set; }

        /// <summary>
        /// return data in specified fields
        /// </summary>
        public string? Fields { get; set; }

        private const int _maxRating = 5;
        private const int _defaultRating = 0;
        private int _rating = _defaultRating;

        /// <summary>
        /// rating, range from 0 to 5
        /// </summary>
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

        /// <summary>
        /// Tourist routes' id
        /// </summary>
        public List<Guid>? Id { get; set; }

    }
}
