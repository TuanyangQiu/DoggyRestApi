using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.Models
{
    public class OrderedItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Guid TouristRouteId { get; set; }

        public TouristRoute TouristRoute { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(1500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OriginalPrice { get; set; }

        [Required]
        [Range(0.01, 1.0)]
        public double? DiscountPercent { get; set; }

        public DateTime? DepartureTime { get; set; }


        public double? Rating { get; set; }

        public TravelDays? TravelDays { get; set; }

        public TripType? TripType { get; set; }

        public DepartureCity? DepartureCity { get; set; }
    }

}
