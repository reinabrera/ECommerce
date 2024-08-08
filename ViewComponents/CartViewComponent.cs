using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerce2.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartViewComponent(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                List<CartItem> cartItems = await _context.CartItems
                    .Include(c => c.Variant)
                        .ThenInclude(v => v.Image)
                    .Include(c => c.Variant)
                        .ThenInclude(v => v.Terms)
                    .Include(c => c.Product)
                        .ThenInclude(c => c.ProductImages.Where(pi => pi.IsFeatured == true))
                    .Where(c => c.UserId == user.Id)
                    .ToListAsync();

                List<CartItemVM> cartItemsVM = new List<CartItemVM>();
                foreach (CartItem cartItem in cartItems)
                {
                    CartItemVM item = new CartItemVM()
                    {
                        Id = cartItem.Id,
                        Product = cartItem.Product,
                        Variant = cartItem.Variant,
                        ItemCount = cartItem.ItemCount,
                    };
                    cartItemsVM.Add(item);
                }
                return View(cartItemsVM);
            }
            return View();
        }
    }
}
