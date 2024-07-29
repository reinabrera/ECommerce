using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce2.Models.ViewModels
{
    public class TeamMemberVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        [DisplayName("Team Member Photo")]
        [Required(ErrorMessage = "Please choose or upload a background image.")]
        public int? ImageId { get; set; }
        public SiteMedia? Image { get; set; }
    }
}
