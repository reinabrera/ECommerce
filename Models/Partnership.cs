using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce2.Models
{
    public class Partnership
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public int? ImageId { get; set; }
        public SiteMedia? Image { get; set; }
    }
}
