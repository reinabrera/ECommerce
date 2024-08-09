using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int? VariantId { get; set; }
        [JsonIgnore]
        public Variant? Variant { get; set; }
        public int Quantity { get; set; }
    }
}
