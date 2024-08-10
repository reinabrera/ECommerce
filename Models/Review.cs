using System.ComponentModel.DataAnnotations;

namespace ECommerce2.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        [StringLength(300, MinimumLength = 100)]
        public string ReviewText { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }

        public Review ()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
