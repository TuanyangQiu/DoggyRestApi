namespace DoggyRestApi.ResourceParameter
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

    }
}
