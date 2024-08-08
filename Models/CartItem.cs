using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int? VariantId { get; set; }
        public Variant? Variant { get; set; }
        public int ItemCount { get; set; }
    }
}
