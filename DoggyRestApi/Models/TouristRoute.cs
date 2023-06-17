using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoggyRestApi.Models
{
    public class TouristRoute
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(1500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

        [Range(0.01, 1.0)]
        public double? DiscountPercent { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        [MaxLength]
        public string Features { get; set; }=string.Empty;
        [MaxLength]
        public string Fees { get; set; } = string.Empty;
        [MaxLength]
        public string Notes { get; set; } = string.Empty;

        public ICollection<TouristRoutePicture> TouristRoutePictures { get; set; } = new List<TouristRoutePicture>();


        public double? Rating { get; set; }

        public TravelDays? TravelDays { get; set; }

        public TripType? TripType { get; set; }

        public DepartureCity? DepartureCity { get; set; }

    }
}
