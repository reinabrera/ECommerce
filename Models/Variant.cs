using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public ICollection<Term> Terms { get; set; }
        [Precision(16, 2)]
        public decimal? ListPrice { get; set; }
        [Precision(16, 2)]
        public decimal? SalePrice { get; set; }
        public int? Inventory { get; set; }
        public int? ImageId { get; set; }
        public ProductImage? Image { get; set; }
        public string TermsConcatenated { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }

        public decimal? GetDisplayPrice()
        {
            if (SalePrice != null)
            {
                return (decimal)SalePrice;
            }

            if (ListPrice != null)
            {
                return (decimal)ListPrice;
            }

            return null;
        }
    }
}
