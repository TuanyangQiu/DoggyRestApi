using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoggyRestApi.DTOs
{
    public class UpdateTouristRouteDTO
    {
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

        [Required]
        public string Features { get; set; } = string.Empty;
        public string Fees { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;


        public double? Rating { get; set; }

        public string? TravelDays { get; set; }

        public string? TripType { get; set; }

        public string? DepartureCity { get; set; }

        public ICollection<NewTouristRoutePictureDTO>? TouristRoutePictures { get; set; }

    }
}
