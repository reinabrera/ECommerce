namespace ECommerce2.Models.ViewModels
{
    public class ProductCardVM
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ProductImage FeaturedImage { get; set; }
        public string Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public List<List<Term>> VariantTermsGrouped { get; set; }
    }
}
