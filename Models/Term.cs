namespace ECommerce2.Models
{
    public class Term
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ColorValue { get; set; }
        public int AttributeId { get; set; }
        public AttributeModel? Attribute { get; set; }
    }
}
