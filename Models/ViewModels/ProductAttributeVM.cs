namespace ECommerce2.Models.ViewModels
{
    public class ProductAttributeVM
    {
        public Guid ProductId { get; set; }
        public List<AttributeVM> Attributes { get; set; }
    }

    public class AttributeVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<TermVM> Terms { get; set; }
    }

    public class TermVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
