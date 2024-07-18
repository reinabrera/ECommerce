namespace ECommerce2.Models
{
    public class ProductAdditionalDetail
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
