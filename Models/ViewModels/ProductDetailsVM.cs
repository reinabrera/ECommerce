namespace ECommerce2.Models.ViewModels
{
    public class ProductDetailsVM
    {
        public Guid ProductId { get; init; }
        public string Name { get; init; }
        public string Overview { get; init; }
        public string Description { get; init; }
        public int Inventory { get; set; }
        public List<string> Categories { get; init; }
        public decimal? ListPrice { get; init; }
        public decimal? SalePrice { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public decimal? ShippingFee { get; init; }
        public List<Variant>? Variant { get; init; }
        public List<ProductCardVM>? RelatedProducts { get; init; }
    }
}
