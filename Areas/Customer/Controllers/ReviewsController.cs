using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using ECommerce2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce2.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = UserRoles.Customer + ", " + UserRoles.Admin)]
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Add(ReviewVM review, string returnUrl = null)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            if (review == null && currentUser == null)
            {
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                return RedirectToAction("Store", "Home");
            }

            Review createReview = new Review()
            {
                User = currentUser,
                ProductId = review.ProductId,
                ReviewText = review.ReviewText,
                Rating = review.Rating,
                CreatedDate = DateTime.Now,
            };
            
            _context.Reviews.Add(createReview);
            await _context.SaveChangesAsync();

            return LocalRedirect(returnUrl);
        }
    }
}
