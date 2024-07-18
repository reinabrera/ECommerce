using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        //public int? FeaturedImageId { get; set; }
        //[ForeignKey("FeaturedImageId")]
        //[ValidateNever]
        //public ProductImage FeaturedImage { get; set; }
        public ICollection<ProductAdditionalImage>? AdditionalImages { get; set; }
        public string? Overview { get; set; }
        public string? Description { get; set; }
        public int? ListPrice { get; set; }
        public int? SalePrice { get; set; }
        public int? Inventory { get; set; }
        public int? ShippingFee { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<ProductAdditionalDetail>? AdditionalDetails { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
        public Product()
        {
            CreatedDate = DateTime.Now;
            IsPublished = false;
        }
    }
}
