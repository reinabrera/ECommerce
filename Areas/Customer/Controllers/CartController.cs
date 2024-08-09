using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using ECommerce2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            List<CartItem> cartItems = await _context.CartItems
                .Include(c => c.Variant)
                    .ThenInclude(v => v.Image)
                .Include(c => c.Variant)
                    .ThenInclude(v => v.Terms)
                .Include(c => c.Product)
                    .ThenInclude(c => c.ProductImages.Where(pi => pi.IsFeatured == true))
                .Where(c => c.User == currentUser)
                .ToListAsync();

            List<CartItemVM> cartItemVMs = new List<CartItemVM> ();
            foreach (CartItem item in cartItems)
            {
                CartItemVM itemVM = new CartItemVM()
                {
                    Id = item.Id,
                    Product = item.Product,
                    Variant = item.Variant,
                    Quantity = item.Quantity,
                };
                cartItemVMs.Add(itemVM);

            }
                 
            return View(cartItemVMs);
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
                Product product = await _context.Products
                    .Include(p => p.Variations)
                    .FirstOrDefaultAsync(p => p.Id == data.ProductId);

                bool productVariationState = product.Variations.Any() == (data.VariantId != null);

                if (product == null || currentUser == null || data.Quantity <= 0 || !productVariationState) 
                {
                    ViewBag.AddToCartError = "There was an error while adding product to cart.";
                    return RedirectToAction("Store", "Home");
                }

                Variant? productVariant = await _context.Variations
                    .FirstOrDefaultAsync(v => v.ProductId == data.ProductId && v.Id == data.VariantId);
                CartItem? existingCartItem = await _context.CartItems
                    .FirstOrDefaultAsync(ci => ci.ProductId == product.Id
                    && (productVariant == null || ci.VariantId == productVariant.Id));

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += data.Quantity;
                    _context.CartItems.Update(existingCartItem);
                } else
                {
                    CartItem addCart = new CartItem()
                    {
                        Product = product,
                        User = currentUser,
                        Variant = productVariant,
                        Quantity = data.Quantity,
                    };
                    _context.CartItems.Add(addCart);
                }

                await _context.SaveChangesAsync();

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction( "Details", "Products", new { Id = product.Slug });
            }

            ViewBag.AddToCartError = "There was an error while adding product to cart.";
            return RedirectToAction("Store", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int cartId)
        {
            if (cartId == 0)
            {
                return Json(new { status = "Error", message = "There was an error removing product from cart" });
            }

            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
           
            if (currentUser != null)
            {
                CartItem itemToRemove = await _context.CartItems.FirstOrDefaultAsync(ci => ci.User == currentUser && ci.Id == cartId);

                if (itemToRemove != null)
                {
                    _context.CartItems.Remove(itemToRemove);
                    await _context.SaveChangesAsync();
                }

                IQueryable<CartItem> updatedCart = _context.CartItems
                    .Where(ci => ci.User == currentUser)
                    .AsQueryable();

                decimal? updatedTotalSum = await updatedCart
                    .SumAsync(ci => (ci.Variant.SalePrice ?? ci.Variant.ListPrice ?? ci.Product.SalePrice ?? ci.Product.ListPrice) * ci.Quantity);

                var toSerialize = new
                {
                    Removed = itemToRemove,
                    UpdatedTotalSum = updatedTotalSum,
                    CartCount = await updatedCart.CountAsync()
                };

                return Json(new { status = "Success", data = JsonConvert.SerializeObject(toSerialize) });
            }

            return Json(new { status = "Failed", message = "There was an error removing product from cart" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCartItems([FromBody] UpdateCartVM data)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            if (data != null)
            {
                if (currentUser != null)
                {
                    List<CartItemVM> updated = new List<CartItemVM>();
                    foreach (UpdateCartItemVM item in data.CartItems)
                    {
                        CartItem toUpdate = await _context.CartItems
                            .Include(ci => ci.Product)
                            .Include(ci => ci.Variant)
                            .FirstOrDefaultAsync(ci => ci.User == currentUser && ci.Id == item.Id);

                        if (toUpdate != null && item.Quantity > 0)
                        {
                            toUpdate.Quantity = item.Quantity;
                            _context.CartItems.Update(toUpdate);

                            decimal? subtotal = (toUpdate.Variant?.SalePrice ?? toUpdate.Variant?.ListPrice ?? toUpdate.Product.SalePrice ?? toUpdate.Product.ListPrice) * toUpdate.Quantity;

                            CartItemVM itemVM = new CartItemVM
                            {
                                Id = toUpdate.Id,
                                Quantity = toUpdate.Quantity,
                                Subtotal = subtotal,
                            };

                            updated.Add(itemVM);
                        }
                    }

                    try
                    {
                        await _context.SaveChangesAsync();

                        var toSerialize = new
                        {
                            Total = updated.Sum(u => u.Subtotal),
                            Updated = updated,
                        };

                        return Json(new { status = "Success", data = JsonConvert.SerializeObject(toSerialize) });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { status = "Error", message = "There was an error while updating cart." });
                    }
                }
            }

            return Json(new { status = "Success" });
        }
    }
}
