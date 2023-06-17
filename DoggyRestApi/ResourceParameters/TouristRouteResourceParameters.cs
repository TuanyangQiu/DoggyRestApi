using Microsoft.AspNetCore.JsonPatch.Operations;
using System.Text.RegularExpressions;

namespace DoggyRestApi.ResourceParameters
{
    public class TouristRouteResourceParameters
    {

        public string? Keyword { get; set; }

        public string? OperationType { get; set; }
        public int? Score { get; set; }

        private string? _rating = string.Empty;
        public string? Rating
        {
            //  { get; }
            get { return _rating; }
            set
            {
                _rating = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Match match = Regex.Match(value, @"([a-zA-Z]+)(\d+)");
                    if (match.Success)
                    {
                        OperationType = match.Groups[1].Value;
                        Score = int.Parse(match.Groups[2].Value);
                    }
                }
            }
        }
    }
}
