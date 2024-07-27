namespace ECommerce2.Models
{
    public class AttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AttributeType Type { get; set; }
        public ICollection<Term>? Terms { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
    public enum AttributeType
    {
        Button,
        Color,
    }
}
