using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoggyRestApi.Models;

namespace DoggyRestApi.DTOs
{
    public class OrderedItemDTO
    {
        public long Id { get; set; }

        //public TouristRouteDTO TouristRoute { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public decimal OriginalPrice { get; set; }

        public double? DiscountPercent { get; set; }

        public DateTime? DepartureTime { get; set; }


        public double? Rating { get; set; }

        public TravelDays? TravelDays { get; set; }

        public TripType? TripType { get; set; }

        public DepartureCity? DepartureCity { get; set; }

    }
}
