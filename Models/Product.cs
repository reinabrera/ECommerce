﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsFeatured { get; set; }
        public ICollection<AdditionalImage>? AdditionalImages { get; set; }
        public string? Overview { get; set; }
        public string? Description { get; set; }
        [Precision(16, 2)]
        public decimal? ListPrice { get; set; }
        [Precision(16, 2)]
        public decimal? SalePrice { get; set; }
        [Precision(16, 2)]
        public decimal? ShippingFee { get; set; }
        public int? Inventory { get; set; }
        [Precision(16, 2)]
        public decimal? MinPrice { get; set; }
        [Precision(16, 2)]
        public decimal? MaxPrice { get; set; }
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
            IsFeatured = false;
            if (SalePrice != null)
            {
                MinPrice = SalePrice;
                MaxPrice = SalePrice;
            } else
            {
                MinPrice = ListPrice;
                MaxPrice = ListPrice;
            }
        }
    }
}