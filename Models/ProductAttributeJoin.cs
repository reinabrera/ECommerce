namespace ECommerce2.Models
{
    public class ProductAttributeJoin
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int AttributeId { get; set; }
        public AttributeModel Attribute { get; set; }
    }
}