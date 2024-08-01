namespace ECommerce2.Models.ViewModels
{
    public class StoreVM
    {
        public List<ProductCardVM> Products { get; set; }
        public int ProductPageCount { get; set; }
        public List<StoreCategoryVM> Categories { get; set; }
    }

    public class StoreCategoryVM
    {
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
