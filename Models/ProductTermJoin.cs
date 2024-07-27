namespace ECommerce2.Models
{
    public class ProductTermJoin
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int TermId { get; set; }
        public Term Term { get; set; }
    }
}
