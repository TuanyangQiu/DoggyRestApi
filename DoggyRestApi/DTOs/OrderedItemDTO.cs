using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoggyRestApi.Models;

namespace DoggyRestApi.DTOs
{
    public class OrderedItemDTO
    {
        public long Id { get; set; }

        public TouristRouteDTO TouristRoute { get; set; }

        public decimal OriginalPrice { get; set; }

        public double? DiscountPercent { get; set; }
    }
}
