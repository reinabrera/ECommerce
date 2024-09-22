using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Slugify;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace ECommerce2.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Slug { get; set; }
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
        public ICollection<Category>? Categories { get; set; }
        public ICollection<AttributeModel>? Attributes { get; set; }
        public ICollection<Term>? SelectedTerms { get; set; }
        public ICollection<Variant>? Variations { get; set; }
        public ICollection<AdditionalDetail>? AdditionalDetails { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
        public Product()
        {
            CreatedDate = DateTime.Now;
            IsPublished = false;
            IsFeatured = false;
            ListPrice = 0;
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

        public decimal GetDisplayPrice()
        {
            if (SalePrice != null)
            {
                return (decimal)SalePrice;
            }

            return (decimal)ListPrice;
        }
        public void UpdateMinManPriceIfNull()
        {
            if (MinPrice == null && MaxPrice == null)
            {
                if (SalePrice != null)
                {
                    MinPrice = SalePrice;
                    MaxPrice = SalePrice;
                }
                else
                {
                    MinPrice = ListPrice;
                    MaxPrice = ListPrice;
                }
            }
        }
        public void UpdatePriceRange()
        {
            if (Variations.Any())
            {
                decimal? salePriceMin = int.MaxValue;
                decimal? salePriceMax = 0;

                decimal? listPriceWithoutSalePriceMin = int.MaxValue;
                decimal? listPriceWithoutSalePriceMax = 0;

                foreach (Variant variant in Variations)
                {
                    if (variant.SalePrice != null)
                    {
                        if (variant.SalePrice < salePriceMin) salePriceMin = variant.SalePrice;
                        if (variant.SalePrice > salePriceMax) salePriceMax = variant.SalePrice;
                    }
                    else
                    {
                        if (variant.ListPrice < listPriceWithoutSalePriceMin) listPriceWithoutSalePriceMin = variant.ListPrice;
                        if (variant.ListPrice > listPriceWithoutSalePriceMax) listPriceWithoutSalePriceMax = variant.ListPrice;
                    }
                }

                if (salePriceMin < listPriceWithoutSalePriceMin)
                {
                    MinPrice = salePriceMin;
                }
                else
                {
                    MinPrice = listPriceWithoutSalePriceMin;
                }

                if (salePriceMax > listPriceWithoutSalePriceMax)
                {
                    MaxPrice = salePriceMax;
                }
                else
                {
                    MaxPrice = listPriceWithoutSalePriceMax;
                }
            }
        }

        public List<Variant> GenerateVariation()
        {
            List<List<Term>> termsDividedByAttr = SelectedTerms.GroupBy(a => a.AttributeId).Select(g => g.ToList()).ToList();
            
            return GenerateTermCombinations(termsDividedByAttr);
        }

        private List<Variant> GenerateTermCombinations(List<List<Term>> terms, int n = 0, List<Term> current = null, List<Variant> variations = null)
        {
            if (current == null) current = new List<Term>();
            if (variations == null) variations = new List<Variant>();

            if (n == terms.Count)
            {
                Variant variant = new Variant()
                {
                    Terms = new List<Term>(current),
                    TermsConcatenated = string.Join(", ", current.OrderBy(c => c.Id).Select(c => c.Id)),
                };
                variations.Add(variant);
            }
            else
            {
                foreach (Term term in terms[n])
                {
                    current.Add(term);
                    GenerateTermCombinations(terms, n + 1, current, variations);
                    current.RemoveAt(current.Count - 1);
                }
            }

            return variations;
        }

        public void GenerateSlug()
        {
            SlugHelper helper = new SlugHelper();

            string slugTemp = helper.GenerateSlug(Name);

            Slug = string.Join("-", slugTemp, Id);
        }
    }
}