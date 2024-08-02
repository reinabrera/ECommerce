using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ECommerce2.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomePageVM homePageVM = new();

            List<Partnership> Partnerships = await _context.Partnerships
                .Include(p => p.Image)
                .ToListAsync();

            List<SpecialPromotion> SpecialPromotions = await _context.SpecialPromotions.Include(sp => sp.SiteMedia).ToListAsync();

            List<Product> FeaturedProducts = await _context.Products
                .Include(p => p.SelectedTerms)
                .Where(p => p.IsFeatured).ToListAsync();

            List<ProductCardVM> productCards = new List<ProductCardVM>();

            foreach (Product product in FeaturedProducts)
            {
                ProductCardVM card = new ProductCardVM()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Category = await _context.ProductCategories.Where(pc => pc.ProductId == product.Id).Select(pc => pc.Category.Name).FirstOrDefaultAsync(),
                    FeaturedImage = await _context.ProductImages.FirstOrDefaultAsync(pi => pi.ProductId == product.Id && pi.IsFeatured == true),
                    ListPrice = product.ListPrice,
                    SalePrice = product.SalePrice,
                    SelectedTermsGrouped = product.SelectedTerms.OrderBy(st => st.AttributeId).GroupBy(st => st.AttributeId).Select(g => g.ToList()).ToList(),
                };

                int variantCount = await _context.Variations.Where(v => v.ProductId == product.Id).CountAsync();

                if (variantCount > 1 && product.MinPrice != product.MaxPrice)
                {
                    card.MinPrice = product.MinPrice;
                    card.MaxPrice = product.MaxPrice;
                }

                productCards.Add(card);
            }

            homePageVM.Partnerships = Partnerships;
            homePageVM.SpecialPromotions = SpecialPromotions;
            homePageVM.FeaturedProducts = productCards;

            return View(homePageVM);
        }

        public async Task<IActionResult> Store(string? query, string? category, int? sliderMinVal, int? sliderMaxVal, int? pageNumber, string? orderBy)
        {
            int pageSize = 12;
            ViewData["PageSize"] = 12;
            int skipCount = 0;
            int productsCount;
            ViewData["CurrentPage"] = 1;

            StoreVM storeVM = new StoreVM();
            storeVM.Categories = new List<StoreCategoryVM>();
            storeVM.BestSelling = new List<ProductCardListItemVM>();
            IQueryable<Product> products = _context.Products.Include(p => p.Variations).AsQueryable();


            /** Best Selling Product - UNFINISHED **/
            List<Product> topProducts = new List<Product>(await products.Take(5).ToListAsync());

            foreach (Product product in topProducts)
            {

                int variantCount = product.Variations.Count();
                decimal? minPrice = null;
                decimal? maxPrice = null;

                if (variantCount > 1 && product.MinPrice != product.MaxPrice)
                {
                    minPrice = product.MinPrice;
                    maxPrice = product.MaxPrice;
                }

                ProductCardListItemVM listItem = new ProductCardListItemVM()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Image = await _context.ProductImages.FirstOrDefaultAsync(pi => pi.ProductId == product.Id && pi.IsFeatured == true),
                    ListPrice = product.ListPrice,
                    SalePrice = product.SalePrice,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                };

                storeVM.BestSelling.Add(listItem);
            }

            products = products.Include(p => p.Categories).Include(p => p.SelectedTerms);

            if (query != null)
            {
                ViewData["CurrentQuery"] = query;
                products = products.Where(p => p.Name.Contains(query) || p.Description.Contains(query) || p.Overview.Contains(query) || p.Categories.Select(c => c.Name).Contains(query));
            }

            if (pageNumber != null)
            {
                ViewData["CurrentPage"] = pageNumber;
            }

            if (category != null)
            {
                ViewData["SelectedCategory"] = category;
                products = products.Where(p => p.Categories.Select(c => c.Name).Contains(category));
            }

            productsCount = products.Count();
            if (productsCount != 0)
            {
                ViewData["SliderMin"] = (int)products.Select(p => p.MinPrice).Min()!;
                ViewData["SliderMax"] = (int)products.Select(p => p.MaxPrice).Max()!;
            }

            if (sliderMinVal != null && sliderMaxVal != null)
            {
                ViewData["SliderMinVal"] = sliderMinVal;
                ViewData["SliderMaxVal"] = sliderMaxVal;
                products = products.Where(p => p.MinPrice >= sliderMinVal && p.MaxPrice <= sliderMaxVal);
                productsCount = products.Count();
            }

            if (orderBy != null)
            {
                ViewData["OrderBy"] = orderBy;

                switch (orderBy)
                {
                    case "date":
                        products = products.OrderBy(p => p.CreatedDate);
                        break;
                    case "price":
                        products = products.OrderBy(p => p.MinPrice);
                        break;
                    case "price-desc":
                        products = products.OrderByDescending(p => p.MinPrice);
                        break;
                    default:
                        break;
                }
            }

            ViewData["ProductCount"] = productsCount;

            storeVM.ProductPageCount = (productsCount + pageSize - 1) / pageSize;

            if (pageNumber != null && pageNumber > 1)
            {
                skipCount = ((int)pageNumber - 1) * pageSize;
            }

            /** Retrieve Product after Query **/
            List<Product> productList = await products.Skip(skipCount).Take(pageSize).ToListAsync();

            /** Categories **/
            List<Category> categories = await _context.Categories
                .Include(p => p.Products)
                .Where(c => c.Products.Count > 0)
                .OrderBy(c => c.Name)
                .ToListAsync();

            foreach (Category item in categories)
            {
                StoreCategoryVM categoryVM = new StoreCategoryVM()
                {
                    Name = item.Name,
                    ProductCount = item.Products.Count(),
                };
                storeVM.Categories.Add(categoryVM);
            }


            /** Mapping Products to ProductCardVM **/
            List<ProductCardVM> productCards = new List<ProductCardVM>();

            foreach (Product product in productList) 
            {
                ProductCardVM productCardVM = new ProductCardVM()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Category = await _context.ProductCategories.Where(pc => pc.ProductId == product.Id).OrderBy(pc => pc.Order).Select(pc => pc.Category.Name).FirstOrDefaultAsync(),
                    FeaturedImage = await _context.ProductImages.FirstOrDefaultAsync(pi => pi.ProductId == product.Id && pi.IsFeatured == true),
                    ListPrice = product.ListPrice,
                    SalePrice = product.SalePrice,
                    SelectedTermsGrouped = product.SelectedTerms.OrderBy(st => st.AttributeId).GroupBy(st => st.AttributeId).Select(g => g.ToList()).ToList(),
                };

                int variantCount = product.Variations.Count();

                if (variantCount > 1 && product.MinPrice != product.MaxPrice)
                {
                    productCardVM.MinPrice = product.MinPrice;
                    productCardVM.MaxPrice = product.MaxPrice;
                }

                productCards.Add(productCardVM);
            }

            storeVM.Products = productCards;

            return View(storeVM);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public async Task<IActionResult> AboutUs()
        {
            List<TeamMember> teamMembers = await _context.Team.Include(t => t.Image).ToListAsync();
            return View(teamMembers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
