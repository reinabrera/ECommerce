namespace ECommerce2.Models.ViewModels
{
    public class UpdateCartVM
    {
        public List<UpdateCartItemVM> CartItems { get; set; }
    }
    public class UpdateCartItemVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
