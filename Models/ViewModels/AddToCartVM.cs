namespace ECommerce2.Models.ViewModels
{
    public class AddToCartVM
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int? VariantId { get; set; }
        public int ItemCount { get; set; }
    }
}
