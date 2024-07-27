using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class AdditionalImage
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public ProductImage Image { get; set; }
        public int SortOrder { get; set; }
    }
}
