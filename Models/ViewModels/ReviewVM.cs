using System.ComponentModel.DataAnnotations;

namespace ECommerce2.Models.ViewModels
{
    public class ReviewVM
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        [StringLength(300, MinimumLength = 100)]
        public string ReviewText { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
