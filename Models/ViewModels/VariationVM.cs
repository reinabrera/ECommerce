namespace ECommerce2.Models.ViewModels
{
    public class VariationVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<VariationItemsVM> VariationItems { get; set; }
    }
    public class VariationItemsVM
    {
        public int? Id { get; set; }
        public string Value { get; set; }
        public double? ListPrice { get; set; }
        public double? SalePrice { get; set; }
        public int? ImageId { get; set; }
        public ProductImage? Image { get; set; }
    }

}


