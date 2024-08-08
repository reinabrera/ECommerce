using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using ECommerce2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECommerce2.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = UserRoles.Customer + ", " + UserRoles.Admin)]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ILogger<CartController> logger, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToCartVM data, string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.GetUserAsync(User);
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == data.ProductId);
                Variant productVariant = await _context.Variations.FirstOrDefaultAsync(v => v.ProductId == data.ProductId && v.Id == data.VariantId);

                if (product == null || currentUser == null || productVariant == null || data.ItemCount <= 0) 
                {
                    ViewBag.AddToCartError = "There was an error while adding product to cart.";
                    return RedirectToAction("Store", "Home");
                }

                CartItem addCart = new CartItem()
                {
                    Product = product,
                    User = currentUser,
                    Variant = productVariant,
                    ItemCount = data.ItemCount,
                };

                _context.CartItems.Add(addCart);
                await _context.SaveChangesAsync();

                if (returnUrl != null)
                {
                    LocalRedirect(returnUrl);
                }

                return RedirectToAction( "Details", "Products", new { Id = product.Slug });
            }

            ViewBag.AddToCartError = "There was an error while adding product to cart.";
            return RedirectToAction("Store", "Home");
        }
    }
}
