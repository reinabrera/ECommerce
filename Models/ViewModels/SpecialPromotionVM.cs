using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce2.Models.ViewModels
{
    public class SpecialPromotionVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Link")]
        public string Url { get; set; }
        [DisplayName("ButtonText")]
        public string ButtonText { get; set; }

        [DisplayName("Background Image")]
        [Required(ErrorMessage = "Please choose or upload a background image.")]
        public int? SiteMediaId { get; set; }
        public SiteMedia? SiteMedia { get; set; }
    }
}
