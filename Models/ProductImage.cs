using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int SortOrder { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsFromEditor { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public ProductImage()
        {
            IsFeatured = false;
            IsFromEditor = false;
        }
    }
}
