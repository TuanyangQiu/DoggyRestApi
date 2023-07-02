using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoggyRestApi.Models
{
    public class ShoppingCart
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("OwnerId")]
        public string OwnerId { get; set; } = string.Empty;

        public ProjectIdentityUser Owner { get; set; }

        public List<LineItem> LineItems { get; set; } = new List<LineItem>();

    }
}
