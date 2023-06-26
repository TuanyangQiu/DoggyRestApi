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
    }
}
