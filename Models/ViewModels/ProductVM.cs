using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models.ViewModels
{
    public class ProductVM
    {
        //public Product Product { get; set; }
        //[ValidateNever]
        //public List<CategoryVM> Category { get; set; }
        //public ICollection<ProductVariation>? Variations { get; set; }
        //public ICollection<AdditionalImage>? AdditionalImages { get; set; }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Overview { get; set; }
        public string? Description { get; set; }
        public int? FeaturedImageId { get; set; }
        public ProductImage? FeaturedImage { get; set; }
        public List<AdditionalImageVM>? AdditionalImages { get; set; }
        public int? ListPrice { get; set; }
        public int? SalePrice { get; set; }
        public int? Inventory { get; set; }
        public int? ShippingFee { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public List<VariationVM>? Variations { get; set; }
        public List<AdditionalDetailVM>? AdditionalDetails { get; set; }
        public bool IsPublished { get; set; }
    }
}
