using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class Variation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public ICollection<VariationItem> VariationItems { get; set; }
    }
}
