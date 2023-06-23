namespace DoggyRestApi.Models
{
    public class QueryTouristRoutesParam
    {
        public string? Keyword { get; set; }

        public int? Rating { get; set; }

        public List<Guid>? Id { get; set; }

    }
}
