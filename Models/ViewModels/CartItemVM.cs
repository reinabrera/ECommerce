namespace ECommerce2.Models.ViewModels
{
    public class CartItemVM
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Variant? Variant { get; set; }
        public ProductImage Image { get; set; }
        public int ItemCount { get; set; }
    }
}
