using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing;
using System.Linq;


namespace ECommerce2.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GetProductVariantData(Guid productId, List<int> termId)
        {
            termId = termId.OrderBy(x => x).ToList();

            string concatenatedTermIds = string.Join(", ", termId);

            Variant variantData = await _context.Variations
                .Include(v => v.Image)
                .Include(v => v.Terms)
                .Where(v => v.ProductId == productId && v.TermsConcatenated == concatenatedTermIds)
                .FirstOrDefaultAsync();

            return Json(new { status = "Success", data = JsonConvert.SerializeObject(variantData) });
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
                .Include(p => p.Categories)
                .Include(p => p.SelectedTerms)
                .Include(p => p.Variations)
                    .ThenInclude(v => v.Image)
                 .Include(p => p.Variations)
                    .ThenInclude(v => v.Terms)
                .Include(v => v.Attributes)
                .Include(v => v.AdditionalDetails)
                .Include(v => v.AdditionalImages)
                    .ThenInclude(ai => ai.Image)
                .Include(v => v.ProductImages)
                .FirstOrDefaultAsync(p => p.Slug == id);

            if (product == null)
            {
                return NotFound();
            }


            decimal? minPrice = null;
            decimal? maxPrice = null;
            if (product.Variations.Count > 1 && product.MinPrice != product.MaxPrice)
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
                Images = new List<ProductImageVM>(),
                AdditionalDetails = new List<AdditionalDetailVM>(),
                RelatedProducts = new List<ProductCardVM>(),
                VariantTermsGrouped = product.Variations.SelectMany(v => v.Terms).GroupBy(t => t.AttributeId).Select(g => g.Distinct().ToList()).ToList()
            };

            /** Product Images **/

            List<ProductImage> distinctImgs = product.Variations.Select(v => v.Image)
                .Concat(product.AdditionalImages.Select(v => v.Image))
                .Concat(product.ProductImages.Where(pi => pi.IsFeatured == true))
                .Distinct().OrderByDescending(i => i.IsFeatured).ToList();

            foreach (ProductImage item in distinctImgs)
            {
                ProductImageVM itemVM = new ProductImageVM()
                {
                    Id = item.Id,
                    FileName = item.FileName,
                    FilePath = item.FilePath,
                };
                productDetailsVM.Images.Add(itemVM);
            }

            foreach (AdditionalDetail additionalDetail in product.AdditionalDetails) 
            {
                AdditionalDetailVM item = new AdditionalDetailVM()
                {
                    Name = additionalDetail.Name,
                    Value = additionalDetail.Value,
                };
                productDetailsVM.AdditionalDetails.Add(item);
            }

            if (product.SelectedTerms.Any())
            {
                List<List<Term>> groupedTerms = product.SelectedTerms.GroupBy(st => st.AttributeId).Select(g => g.ToList()).ToList();

                int attrId = 0;

                foreach (List<Term> grp in groupedTerms)
                {
                    string attrName = product.Attributes.Where(a => a.Id == grp[0].AttributeId).Select(a => a.Name).FirstOrDefault();

                    if (attrName != null)
                    {
                        AdditionalDetailVM item = new AdditionalDetailVM()
                        {
                            Name = attrName,
                            Value = string.Join(", ", grp.Select(t => t.Name)),
                        };
                        productDetailsVM.AdditionalDetails.Add(item);
                    }
                }
            }

            List<Product> relatedProducts = await _context.Products
                .Include(p => p.ProductImages.Where(pi => pi.IsFeatured == true))
                .Include(p => p.Variations)
                    .ThenInclude(v => v.Terms)
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
                        VariantTermsGrouped = relatedProduct.Variations.SelectMany(v => v.Terms).GroupBy(t => t.AttributeId).Select(g => g.Distinct().ToList()).ToList(),
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
