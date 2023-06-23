namespace DoggyRestApi.DTOs
{
    public class QueryTouristRoutesParamDTO
    {
        public string? Keyword { get; set; }
        public int? Rating { get; set; }
        public List<Guid>? Id { get; set; }
    }
}
