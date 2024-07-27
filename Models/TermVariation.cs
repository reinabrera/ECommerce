using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class TermVariation
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }
        public int VariantId { get; set; }
        [ForeignKey("VariantId")]
        public Variant Variant { get; set; }
    }
}
