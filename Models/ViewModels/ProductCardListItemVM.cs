namespace ECommerce2.Models.ViewModels
{
    public class ProductCardListItemVM
    {
        public Guid ProductId { get; init; }
        public string Name { get; init; }
        public ProductImage Image { get; init; }
        public decimal? ListPrice { get; init; }
        public decimal? SalePrice { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
    }
}
