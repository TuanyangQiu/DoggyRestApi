using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoggyRestApi.Models
{
    public class LineItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Guid? TouristRouteId { get; set; }


        public Guid ShoppingCartId { get; set; }

        [Required]
        public ShoppingCart? ShoppingCart { get; set; }

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
        public double? DiscountPercent { get; set; } = 1;

        public DateTime? DepartureTime { get; set; }


        public double? Rating { get; set; }

        public TravelDays? TravelDays { get; set; }

        public TripType? TripType { get; set; }

        public DepartureCity? DepartureCity { get; set; }
    }
}
