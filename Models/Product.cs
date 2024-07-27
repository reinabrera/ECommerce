using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<AdditionalImage>? AdditionalImages { get; set; }
        public string? Overview { get; set; }
        public string? Description { get; set; }
        public int? ListPrice { get; set; }
        public int? SalePrice { get; set; }
        public int? Inventory { get; set; }
        public int? ShippingFee { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<AttributeModel>? Attributes { get; set; }
        public ICollection<Term>? SelectedTerms { get; set; }
        public ICollection<Variant>? Variations { get; set; }
        public ICollection<AdditionalDetail>? AdditionalDetails { get; set; }
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