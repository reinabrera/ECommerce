using Microsoft.AspNetCore.Identity;

namespace ECommerce2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<CartItem> CartItems { get; set; }
    }
}
