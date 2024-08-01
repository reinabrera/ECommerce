using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class ProductCategories
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int Order { get; set; }
    }
}
