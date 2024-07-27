using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public ICollection<Term> Terms { get; set; }
        public int? ListPrice { get; set; }
        public int? SalePrice { get; set; }
        public int? Inventory { get; set; }
        public int? ImageId { get; set; }
        public ProductImage? Image { get; set; }
        public string TermsConcatenated { get; set; }
    }
}
