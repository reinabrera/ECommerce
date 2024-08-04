using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models.ViewModels
{
    public class ProductVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsFeatured { get; set; }
        public string Overview { get; set; }
        public string? Description { get; set; }
        public int FeaturedImageId { get; set; }
        public ProductImage? FeaturedImage { get; set; }
        public List<AdditionalImageVM>? AdditionalImages { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? ShippingFee { get; set; }
        public int? Inventory { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public List<AdditionalDetailVM>? AdditionalDetails { get; set; }
        public bool IsPublished { get; set; }
    }
}
