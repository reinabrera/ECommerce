using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace ECommerce2.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductsController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GetProductImageByVariant(Guid productId, List<int> termId)
        {
            termId = termId.OrderBy(x => x).ToList();

            string concatenatedTermIds = string.Join(", ", termId);

            string imgUrl = await _context.Variations
                .Include(v => v.Image)
                .Where(v => v.ProductId == productId && v.TermsConcatenated == concatenatedTermIds)
                .Select(v => v.Image.FilePath).FirstOrDefaultAsync();

            return Json(new { status = "Success", data = JsonConvert.SerializeObject(imgUrl) });
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(p => p.Slug == id);

            int variantCount = await _context.Variations.Where(v => v.ProductId == product.Id).CountAsync();

            decimal? minPrice = null;
            decimal? maxPrice = null;
            if (variantCount > 1 && product.MinPrice != product.MaxPrice)
            {
                minPrice = product.MinPrice;
                maxPrice = product.MaxPrice;
            }

            ProductDetailsVM productDetailsVM = new ProductDetailsVM()
            {
                ProductId = product.Id,
                Name = product.Name,
                Overview = product.Overview,
                Description = product.Description,
                Categories = product.Categories.Select(c => c.Name).ToList(),
                ListPrice = product.ListPrice,
                SalePrice = product.SalePrice,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                ShippingFee = product.ShippingFee,
                Inventory = (int)product.Inventory,
                RelatedProducts = new List<ProductCardVM>(),
            };

            List<Product> relatedProducts = await _context.Products
                .Include(p => p.ProductImages.Where(pi => pi.IsFeatured == true))
                .Include(p => p.SelectedTerms)
                .Include(p => p.Categories)
                .Where(p => p.Categories.Any(pc => product.Categories.Contains(pc)))
                .OrderBy(p => Guid.NewGuid())
                .Take(3)
                .ToListAsync();

            if (relatedProducts.Any()) {

                foreach (Product relatedProduct in relatedProducts)
                {
                    ProductCardVM cardVM = new ProductCardVM()
                    {
                        ProductId = relatedProduct.Id,
                        Name = relatedProduct.Name,
                        Slug = relatedProduct.Slug,
                        FeaturedImage = relatedProduct.ProductImages.FirstOrDefault(),
                        Category = await _context.ProductCategories.Where(c => c.ProductId == relatedProduct.Id).OrderBy(c => c.Order).Select(c => c.Category.Name).FirstOrDefaultAsync(),
                        ListPrice = relatedProduct.ListPrice,
                        SalePrice = relatedProduct.SalePrice,
                        SelectedTermsGrouped = relatedProduct.SelectedTerms.GroupBy(st => st.AttributeId).Select(g => g.ToList()).ToList()
                    };

                    int vc = await _context.Variations.Where(v => v.ProductId == relatedProduct.Id).CountAsync();

                    if (vc > 1 && product.MinPrice != product.MaxPrice)
                    {
                        cardVM.MinPrice = product.MinPrice;
                        cardVM.MaxPrice = product.MaxPrice;
                    }
                    productDetailsVM.RelatedProducts.Add(cardVM);
                }
            }

            return View(productDetailsVM);
        }

    }
}
