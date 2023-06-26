using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.DTOs
{
    public class AddItem2ShoppingCartDTO
    {
        [Required]
        public Guid TouristRouteId { get; set; }
    }
}
