using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class VariationItem
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public ProductImage? Image { get; set; }
        public double? ListPrice { get; set; }
        public double? SalePrice { get; set; }
        public int Inventory { get; set; }
        public int VariationId { get; set; }
        [ForeignKey("VariationId")]
        public Variation Variation { get; set; }
    }
}   
