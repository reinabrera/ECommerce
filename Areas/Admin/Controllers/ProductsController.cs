using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using System.Security.Policy;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using HtmlAgilityPack;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;
using Slugify;
using Newtonsoft.Json;

namespace ECommerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static Guid productId;
        private List<ProductImage> ProductImages;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Categories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            Product createProduct = new Product();

            _context.Products.Add(createProduct);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { createProduct.Id });
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FeaturedImageId,Overview,Description,ListPrice,SalePrice,Inventory,ShippingFee,CategoryId,IsPublished,CreatedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.AdditionalImages)
                    .ThenInclude(ai => ai.Image)
                .Include(vi => vi.AdditionalDetails)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                /** Map Product to ProductVM */
                ProductVM mapProduct = new ProductVM()
                {
                    Name = product.Name,
                    IsFeatured = product.IsFeatured,
                    Overview = product.Overview,
                    Description = product.Description,
                    ListPrice = product.ListPrice,
                    SalePrice = product.SalePrice,
                    Inventory = product.Inventory,
                    ShippingFee = product.ShippingFee,
                    IsPublished = product.IsPublished,
                    AdditionalImages = new List<AdditionalImageVM>(),
                    AdditionalDetails = new List<AdditionalDetailVM>(),
                };

                /** Product Categories */
                List<CategoryVM> Categories = new List<CategoryVM>();
                List<ProductCategories> ProductCategories = await _context.ProductCategories.Include(pc => pc.Category).OrderBy(pc => pc.Order).Where(pc => pc.ProductId == id).ToListAsync();

                foreach (ProductCategories cat in ProductCategories)
                {
                    CategoryVM categoryVM = new CategoryVM()
                    {
                        Name = cat.Category.Name,
                    };
                    Categories.Add(categoryVM);
                }
                mapProduct.Categories = Categories;

                /** Images Related */

                if (product.ProductImages != null && product.ProductImages.Any())
                {
                    List<ProductImage> ProductImages = product.ProductImages.ToList();

                    /** Featured Image */
                    ProductImage FeaturedImage = ProductImages.FirstOrDefault(fi => fi.IsFeatured == true);

                    if (FeaturedImage != null)
                    {
                        mapProduct.FeaturedImageId = FeaturedImage.Id;
                        mapProduct.FeaturedImage = FeaturedImage;
                    }

                    if (product.AdditionalImages != null)
                    {
                        foreach (AdditionalImage item in product.AdditionalImages)
                        {
                            AdditionalImageVM additionalImageVM = new AdditionalImageVM()
                            {
                                ImageId = item.ImageId,
                                Image = item.Image,
                            };
                            mapProduct.AdditionalImages.Add(additionalImageVM);
                        }
                    }
                }

                /** Product Additional Details */
                if (product.AdditionalDetails != null && product.AdditionalDetails.Any())
                {
                    foreach (AdditionalDetail AdditionalDetail in product.AdditionalDetails)
                    {
                        AdditionalDetailVM AdditionalDetailVM = new AdditionalDetailVM()
                        {
                            Id = AdditionalDetail.Id,
                            Name = AdditionalDetail.Name,
                            Value = AdditionalDetail.Value,
                        };

                        mapProduct.AdditionalDetails.Add(AdditionalDetailVM);
                    }
                }

                return View(mapProduct);
            }

            return NotFound();

        }



        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductVM productVM)
        {
            if (id != productVM.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    Product UpdateProduct = await _context.Products
                        .Include(p => p.Categories)
                        .Include(p => p.ProductImages)
                        .Include(p => p.AdditionalImages)
                        .Include(p => p.AdditionalDetails)
                        .Where(p => p.Id == id).FirstOrDefaultAsync();

                    if (UpdateProduct == null) return NotFound();

                    /** Initialize Product Images */
                    ProductImages = UpdateProduct.ProductImages.ToList();

                    /** Product Name */
                    UpdateProduct.Name = productVM.Name;

                    /** Slug **/
                    if (UpdateProduct.Name != null)
                    {
                        string idStr = UpdateProduct.Id.ToString();
                        UpdateProduct.Slug = GenerateSlug(UpdateProduct.Name, idStr.Substring(idStr.Length - 12));
                    }

                    /** IsFeatured */
                    UpdateProduct.IsFeatured = productVM.IsFeatured;

                    /** Product Overview */
                    UpdateProduct.Overview = productVM.Overview;

                    /** Product Description */
                    UpdateProduct.Description = productVM.Description != null ? updateProductDescription(productVM.Description, id) : null;

                    /** Product ListPrice */
                    UpdateProduct.ListPrice = productVM.ListPrice;

                    /** Product SalePrice */
                    UpdateProduct.SalePrice = productVM.SalePrice;

                    /** Product Inventory */
                    UpdateProduct.Inventory = productVM.Inventory;

                    /** Product Shipping Fee */
                    UpdateProduct.ShippingFee = productVM.ShippingFee;

                    /** Product Categories */
                    List<ProductCategories> existingProductCategories = await _context.ProductCategories.Where(pc => pc.ProductId ==  id).ToListAsync();
                    _context.ProductCategories.RemoveRange(existingProductCategories);

                    List<ProductCategories> productCategories = await AddOrUpdateCategories(productVM.Categories, id);

                    _context.ProductCategories.UpdateRange(productCategories);

                    if (ProductImages != null)
                    {
                        /** Featured Image */
                        ProductImage PreviousFeaturedImage = ProductImages.FirstOrDefault(fi => fi.IsFeatured == true);

                        if (PreviousFeaturedImage != null) PreviousFeaturedImage.IsFeatured = false;

                        if (productVM.FeaturedImageId != null)
                        {
                            ProductImage UpdateFeaturedImage = ProductImages.FirstOrDefault(fi => fi.Id == productVM.FeaturedImageId);

                            if (UpdateFeaturedImage != null) UpdateFeaturedImage.IsFeatured = true;
                        }

                        UpdateProduct.ProductImages = ProductImages;

                        /** Additional Images */

                        if (productVM.AdditionalImages != null)
                        {
                            UpdateProduct.AdditionalImages.Clear();

                            int i = 0;
                            foreach (AdditionalImageVM item in productVM.AdditionalImages)
                            {
                                ProductImage Image = ProductImages.FirstOrDefault(pi => pi.Id == item.ImageId);

                                if (Image != null)
                                {
                                    AdditionalImage UpdateAdditionalImage = new AdditionalImage()
                                    {
                                        ProductId = id,
                                        ImageId = Image.Id,
                                        SortOrder = i
                                    };
                                    UpdateProduct.AdditionalImages.Add(UpdateAdditionalImage);
                                }
                                i++;
                            }
                        }
                    }

                    /** Product Published */
                    UpdateProduct.IsPublished = productVM.IsPublished;

                    /** Product Additional Details */
                    List<AdditionalDetail> AdditionalDetails = UpdateProduct.AdditionalDetails.ToList();

                    if (productVM.AdditionalDetails != null)
                    {
                        if (AdditionalDetails.Any())
                        {
                            /** Remove Additional Details */
                            for (int i = AdditionalDetails.Count - 1; i >= 0; i--)
                            {
                                AdditionalDetail AdditionalDetail = AdditionalDetails[i];

                                if (!productVM.AdditionalDetails.Any(ai => ai.Id == AdditionalDetail.Id))
                                {
                                    AdditionalDetails.Remove(AdditionalDetail);
                                }
                            }
                        }

                        /** Add or Update Additional Details */

                        foreach (AdditionalDetailVM AdditionalDetailVM in productVM.AdditionalDetails)
                        {
                            if (AdditionalDetailVM.Id != null)
                            {
                                AdditionalDetail UpdateAdditionalDetail = AdditionalDetails.FirstOrDefault(ai => ai.Id == AdditionalDetailVM.Id);

                                if (UpdateAdditionalDetail != null)
                                {
                                    UpdateAdditionalDetail.Name = AdditionalDetailVM.Name;
                                    UpdateAdditionalDetail.Value = AdditionalDetailVM.Value;
                                }
                            }
                            else
                            {
                                AdditionalDetail AddAdditionalDetail = new AdditionalDetail()
                                {
                                    Name = AdditionalDetailVM.Name,
                                    Value = AdditionalDetailVM.Value
                                };
                                AdditionalDetails.Add(AddAdditionalDetail);
                            }
                        }
                    }
                    else
                    {
                        AdditionalDetails.Clear();
                    }

                    UpdateProduct.AdditionalDetails = AdditionalDetails;


                    /** Min and Max Price **/

                    if (UpdateProduct.MinPrice == null && UpdateProduct.MaxPrice == null)
                    {
                        if (UpdateProduct.SalePrice != null)
                        {
                            UpdateProduct.MinPrice = UpdateProduct.SalePrice;
                            UpdateProduct.MaxPrice = UpdateProduct.SalePrice;
                        }
                        else
                        {
                            UpdateProduct.MinPrice = UpdateProduct.ListPrice;
                            UpdateProduct.MaxPrice = UpdateProduct.ListPrice;
                        }
                    }


                    _context.Update(UpdateProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateProductSlug()
        {
            List<Product> products = await _context.Products
                .Where(p => p.Slug == null && p.Name != null)
                .ToListAsync();

            foreach (Product product in products)
            {
                string idStr = product.Id.ToString();
                product.Slug = GenerateSlug(product.Name, idStr.Substring(idStr.Length - 12));
                _context.Products.Update(product);
            }

            await _context.SaveChangesAsync();

            string message = $"Successfully updated {products.Count} product slugs.";

            return Json(new { status = "Success", message = JsonConvert.SerializeObject(message) });
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Categories)
                //.Include(p => p.FeaturedImage)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product != null)
            {

                if (product.ProductImages != null && product.ProductImages.Any())
                {
                    foreach (ProductImage item in product.ProductImages)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, item.FilePath.TrimStart('\\'));

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        _context.ProductImages.Remove(item);
                    }
                }

                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        /* Functions */

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public async Task<List<ProductCategories>> AddOrUpdateCategories(List<CategoryVM> categories, Guid productId)
        {
            List<Category> ExistingCategories = await _context.Categories.ToListAsync();
            List<ProductCategories> ProductCategories = new List<ProductCategories>();

            int order = 1;
            foreach (CategoryVM categoryVM in categories)
            {
                Category ProductCat = ExistingCategories.FirstOrDefault(c => c.Name == categoryVM.Name);

                if (ProductCat != null)
                {
                    ProductCategories productCategory = new ProductCategories()
                    {
                        ProductId = productId,
                        Order = order,
                        Category = ProductCat,
                    };
                    ProductCategories.Add(productCategory);
                }
                else
                {
                    Category newCat = new Category()
                    {
                        Name = categoryVM.Name,
                    };

                    ProductCategories productCategory = new ProductCategories()
                    {
                        ProductId = productId,
                        Order = order,
                        Category = newCat,
                    };

                    _context.Categories.Add(newCat);
                    ProductCategories.Add(productCategory);
                }
                order++;
            }

            return ProductCategories;
        }

        public string updateProductDescription(string description, Guid productId)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(description);

            List<HtmlNode> toBeAdded = new List<HtmlNode>();
            List<string> currentImgs = new List<string>();
            List<ProductImage> wysiywgImgs = ProductImages.Where(e => e.IsFromEditor == true).ToList();

            var imgs = document.DocumentNode.Descendants("img").ToList();

            foreach (var item in imgs)
            {
                string src = item.GetAttributeValue("src", null) ?? "";
                if (!string.IsNullOrEmpty(src))
                {
                    if (src.StartsWith("data:image"))
                    {
                        string currentSrcValue = item.GetAttributeValue("src", null);
                        currentSrcValue = currentSrcValue.Split(',')[1];
                        string filePath = UploadBase64Image(currentSrcValue, productId);
                        item.SetAttributeValue("src", filePath);
                    }
                    else
                    {
                        currentImgs.Add(item.GetAttributeValue("src", null));
                    }
                }
            }

            if (currentImgs != null)
            {
                foreach (ProductImage Image in wysiywgImgs)
                {
                    if (!currentImgs.Contains(Image.FilePath))
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, Image.FilePath.TrimStart('\\'));
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        _context.ProductImages.Remove(Image);
                    }
                }
            }

            string result = document.DocumentNode.OuterHtml;
            return result;
        }

        public string UploadBase64Image(string base64, Guid productId)
        {
            byte[] imageData = Convert.FromBase64String(base64);
            string imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");

            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string fileSavePath = Path.Combine(imagesFolder, fileName);

            System.IO.File.WriteAllBytes(fileSavePath, imageData);

            ProductImage productImage = new ProductImage()
            {
                ProductId = productId,
                FileName = fileName,
                FilePath = @"\ProductImages\" + fileName,
                IsFromEditor = true,
                SortOrder = 99,
            };

            ProductImages.Add(productImage);
            return "\\ProductImages\\" + fileName;
        }

        public string GenerateSlug(string name, string id)        
        {
            SlugHelper helper = new SlugHelper();

            string slugTemp = helper.GenerateSlug(name);

            return string.Join("-", slugTemp, id);
        }
    }
}
