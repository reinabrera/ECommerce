using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce2.Models
{
    public class SpecialPromotion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ButtonText { get; set; }
        public int? SiteMediaId { get; set; }
        public SiteMedia? SiteMedia { get; set; }
    }
}
