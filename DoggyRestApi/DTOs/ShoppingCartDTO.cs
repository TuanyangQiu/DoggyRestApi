using DoggyRestApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.DTOs
{
    public class ShoppingCartDTO
    {

        public Guid Id { get; set; }

        public string OwnerId { get; set; } = string.Empty;

        public ICollection<LineItemDTO>? LineItems { get; set; }
    }
}
