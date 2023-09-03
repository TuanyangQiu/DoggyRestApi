using DoggyRestApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.DTOs
{
    public class LineItemDTO
    {
        public long Id { get; set; }

        public Guid? TouristRouteId { get; set; }

        public decimal OriginalPrice { get; set; }

        public double? DiscountPercent { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime? DepartureTime { get; set; }

        public double? Rating { get; set; }

        public TravelDays? TravelDays { get; set; }

        public TripType? TripType { get; set; }

        public DepartureCity? DepartureCity { get; set; }
    }
}
