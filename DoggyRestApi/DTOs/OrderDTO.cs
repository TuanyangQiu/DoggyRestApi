using DoggyRestApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; } = string.Empty;

        public List<OrderedItemDTO> OrderItems { get; set; }

        public string OrderStatus { get; set; } = string.Empty;

        public DateTime OrderCreationDateTime { get; set; }

        public string TransactionMetaData { get; set; } = string.Empty;
    }
}
