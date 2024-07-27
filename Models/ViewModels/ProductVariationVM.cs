namespace ECommerce2.Models.ViewModels
{
    public class ProductVariationVM
    {
        public Guid ProductId { get; set; }
        public List<VariantVM> Variants { get; set; }
    }

    public class VariantVM
    {
        public int Id { get; set; }
        public int? ListPrice { get; set; }
        public int? SalePrice { get; set; }
        public int? Inventory { get; set; }
        public int? ImageId { get; set; }
    }
}
