namespace DoggyRestApi.DTOs
{
    public class LinkDTO
    {

        public string HRef { get; set; } = string.Empty;
        public string Rel { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;

        public LinkDTO(string href, string rel, string method)
        {
            HRef = href;
            Rel = rel;
            Method = method;
        }
    }
}
