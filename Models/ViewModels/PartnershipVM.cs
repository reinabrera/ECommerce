using System.ComponentModel;

namespace ECommerce2.Models.ViewModels
{
    public class PartnershipVM
    {
        public int Id { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Company Website")]
        public string CompanyWebsite { get; set; }
        [DisplayName("Company Logo")]
        public PartnershipLogo? Logo { get; set; }
        public IFormFile? FileUpload { get; set; }
    }
}
