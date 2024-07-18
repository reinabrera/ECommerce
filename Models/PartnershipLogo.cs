using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class PartnershipLogo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int PartnershipId { get; set; }
        [ForeignKey("PartnershipId")]
        public Partnership Partnership { get; set; }
    }
}
