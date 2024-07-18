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

namespace ECommerce2.Controllers
{
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
                //.Include(p => p.FeaturedImage)
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
            return RedirectToAction("Edit", new {Id = createProduct.Id});
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

            //Product product = await _context.Products
            //    .Include(p => p.FeaturedImage)
            //    .Include(p => p.AdditionalImages)
            //        .ThenInclude(ai => ai.Image)
            //    .Include(p => p.Categories)
            //    .Include(p => p.ProductVariations)
            //        .ThenInclude(pv => pv.VariationItems)
            //            .ThenInclude(vi => vi.Image)
            //    .Include(p => p.AdditionalDetails)
            //    .Where(p => p.Id == id)
            //    .FirstOrDefaultAsync();

            Product product = await _context.Products
                .Include(p => p.Categories)
                .Include(p => p.ProductImages)
                .Include(p => p.AdditionalImages)
                    .ThenInclude(ai => ai.Image)
                .Include(p => p.ProductVariations)
                    .ThenInclude(pv => pv.VariationItems)
                        .ThenInclude(vi => vi.Image)
                .Include(vi => vi.AdditionalDetails)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            //if (product != null && product.AdditionalImages != null) product.AdditionalImages = product.AdditionalImages.OrderBy(p => p.SortOrder).ToList();

            //List<ProductVariation> mapVar = new List<ProductVariation>();
            if (product != null)
            {
                /** Map Product to ProductVM */
                ProductVM mapProduct = new ProductVM()
                {
                    Name = product.Name,
                    Overview = product.Overview,
                    Description = product.Description,
                    ListPrice = product.ListPrice,
                    SalePrice = product.SalePrice,
                    Inventory = product.Inventory,
                    ShippingFee = product.ShippingFee,
                    IsPublished = product.IsPublished,
                    AdditionalImages = new List<AdditionalImageVM>(),
                    Variations = new List<VariationVM>(),
                    AdditionalDetails = new List<AdditionalDetailVM>(),
                };

                /** Product Categories */
                List<CategoryVM> Categories = new List<CategoryVM>();

                foreach (Category cat in product.Categories)
                {
                    CategoryVM categoryVM = new CategoryVM()
                    {
                        Name = cat.Name,
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
                        foreach (ProductAdditionalImage item in  product.AdditionalImages)
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

                /** Product Variations */

                if (product.ProductVariations != null && product.ProductVariations.Any())
                {
                    foreach (Variation ProductVariation in product.ProductVariations)
                    {
                        VariationVM VariationVM = new VariationVM()
                        {
                            Id = ProductVariation.Id,
                            Name = ProductVariation.Name,
                            VariationItems = new List<VariationItemsVM>(),
                        };

                        if (ProductVariation.VariationItems.Any()) 
                        {
                            foreach (VariationItem VariationItem in ProductVariation.VariationItems)
                            {
                                VariationItemsVM VariationItemVM = new VariationItemsVM()
                                {
                                    Id = VariationItem.Id,
                                    Value = VariationItem.Value,
                                    ListPrice = VariationItem.ListPrice,
                                    SalePrice = VariationItem.SalePrice,
                                    ImageId = VariationItem.ImageId,
                                    Image = VariationItem.Image,
                                };
                                VariationVM.VariationItems.Add(VariationItemVM);
                            }
                        }
                        mapProduct.Variations.Add(VariationVM);
                    }
                }

                /** Product Additional Details */
                if (product.AdditionalDetails != null && product.AdditionalDetails.Any())
                {
                    foreach (ProductAdditionalDetail AdditionalDetail in product.AdditionalDetails)
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
                        .Include(p => p.ProductVariations)
                            .ThenInclude(p => p.VariationItems)
                                .ThenInclude(p => p.Image)
                        .Include(p => p.AdditionalDetails)
                        .Where(p => p.Id == id).FirstOrDefaultAsync();

                    if (UpdateProduct == null) return NotFound();

                    /** Initialize Product Images */
                    ProductImages = UpdateProduct.ProductImages.ToList();

                    /** Product Name */
                    UpdateProduct.Name = productVM.Name;

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
                    UpdateProduct.Categories.Clear();
                    UpdateProduct.Categories = await AddOrUpdateCategories(productVM.Categories);


                   
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
                                    ProductAdditionalImage UpdateAdditionalImage = new ProductAdditionalImage()
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

                    /** Product Variations */
                    List<Variation> Variations = UpdateProduct.ProductVariations.ToList();


                    if (productVM.Variations != null)
                    {
                        if (Variations.Any())
                        {
                            /** Remove Variation */

                            for (int i = Variations.Count - 1; i >= 0; i--)
                            {
                                Variation Variation = Variations[i];
                                if (!productVM.Variations.Any(v => v.Id == Variation.Id))
                                {
                                    Variations.Remove(Variation);
                                }
                            }
                        }

                        /** Add or Update Variation */
                        foreach (VariationVM VariationVM in productVM.Variations)
                        {
                            // Update Variation
                            if (VariationVM.Id != null)
                            {
                                Variation ProductVariation = Variations.FirstOrDefault(v => v.Id == VariationVM.Id);
                                if (ProductVariation != null)
                                {
                                    ProductVariation.Name = ProductVariation.Name;
                                    List<VariationItem> VariationItems = ProductVariation.VariationItems.ToList();

                                    if (VariationItems != null)
                                    {
                                        /** Remove Variation Items */

                                        for (int i = VariationItems.Count - 1; i >= 0; i--)
                                        {
                                            VariationItem VariationItem = VariationItems[i];
                                            if (!VariationVM.VariationItems.Any(vi => vi.Id == VariationItem.Id))
                                            {
                                                VariationItems.Remove(VariationItem);
                                            }
                                        }
                                    }

                                    /** Add or Update Variation Items */
                                    foreach (VariationItemsVM VariationItemVM in VariationVM.VariationItems)
                                    {
                                        if (VariationItemVM.Id != null)
                                        {
                                            VariationItem VariationItem = VariationItems.FirstOrDefault(vi => vi.Id == VariationItemVM.Id);
                                            if (VariationItem != null)
                                            {
                                                VariationItem.Value = VariationItemVM.Value;
                                                VariationItem.ImageId = VariationItemVM.ImageId;
                                                VariationItem.ListPrice = VariationItemVM.ListPrice;
                                                VariationItem.SalePrice = VariationItemVM.SalePrice;
                                            }
                                        }
                                        else
                                        {
                                            VariationItem NewItem = new VariationItem()
                                            {
                                                Value = VariationItemVM.Value,
                                                ImageId = VariationItemVM.ImageId,
                                                ListPrice = VariationItemVM.ListPrice,
                                                SalePrice = VariationItemVM.SalePrice,
                                            };
                                            VariationItems.Add(NewItem);
                                        }
                                    }

                                    ProductVariation.VariationItems = VariationItems;
                                }
                            }
                            else
                            {
                                Variation NewVariation = new Variation()
                                {
                                    Name = VariationVM.Name,
                                    ProductId = id,
                                    VariationItems = new List<VariationItem>(),
                                };

                                if (VariationVM.VariationItems != null)
                                {
                                    foreach(VariationItemsVM VariationItemVM in VariationVM.VariationItems)
                                    {
                                        VariationItem NewItem = new VariationItem()
                                        {
                                            Value = VariationItemVM.Value,
                                            ImageId = VariationItemVM.ImageId,
                                            ListPrice = VariationItemVM.ListPrice,
                                            SalePrice = VariationItemVM.SalePrice,
                                        };
                                        NewVariation.VariationItems.Add(NewItem);
                                    }
                                }
                                Variations.Add(NewVariation);
                            }
                        }
                    } else
                    {
                        Variations.Clear();
                    }

                    UpdateProduct.ProductVariations = Variations;

                    /** Product Published */
                    UpdateProduct.IsPublished = productVM.IsPublished;

                    /** Product Additional Details */
                    List<ProductAdditionalDetail> AdditionalDetails = UpdateProduct.AdditionalDetails.ToList();

                    if (productVM.AdditionalDetails != null)
                    {
                        if (AdditionalDetails.Any())
                        {
                            /** Remove Additional Details */
                            for (int i = AdditionalDetails.Count - 1; i >= 0; i--)
                            {
                                ProductAdditionalDetail AdditionalDetail = AdditionalDetails[i];

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
                                ProductAdditionalDetail UpdateAdditionalDetail = AdditionalDetails.FirstOrDefault(ai => ai.Id == AdditionalDetailVM.Id);

                                if (UpdateAdditionalDetail != null)
                                {
                                    UpdateAdditionalDetail.Name = AdditionalDetailVM.Name;
                                    UpdateAdditionalDetail.Value = AdditionalDetailVM.Value;
                                }
                            }
                            else
                            {
                                ProductAdditionalDetail AddAdditionalDetail = new ProductAdditionalDetail()
                                {
                                    Name = AdditionalDetailVM.Name,
                                    Value = AdditionalDetailVM.Value
                                };
                                AdditionalDetails.Add(AddAdditionalDetail);
                            }
                        }
                    } else
                    {
                        AdditionalDetails.Clear();
                    }

                    UpdateProduct.AdditionalDetails = AdditionalDetails;

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
                //.Include(p => p.FeaturedImage)
                //.Include(p => p.FeaturedImage)
                //.Include(p => p.ProductVariations)
                //    .ThenInclude(pv => pv.VariationItems)
                //.Include(p => p.AdditionalDetails)
                //.Include(p => p.AdditionalImages)
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

        public async Task<List<Category>> AddOrUpdateCategory(List<CategoryVM> categoryVMs)
        {
            List<Category> Categories = await _context.Categories.ToListAsync();
            List<Category> ProductCategories = new List<Category>();

            foreach (CategoryVM cat in categoryVMs)
            {
                Category Category = Categories.FirstOrDefault(c => c.Name == cat.Name);
                if (Category != null)
                {
                    ProductCategories.Add(Category);
                }
                else
                {
                    Category newCat = new Category()
                    {
                        Name = cat.Name,
                    };
                    _context.Categories.Add(newCat);
                    ProductCategories.Add(newCat);
                }
            }


            return ProductCategories;

            //Category GetCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);

            //if (GetCategory != null)
            //{
            //    return GetCategory;
            //}
            //else
            //{
            //    Category NewCategory = new Category()
            //    {
            //        Name = name,
            //    };
            //    return NewCategory;
            //}
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public async Task<List<Category>> AddOrUpdateCategories(List<CategoryVM> categories)
        {
            List<Category> ExistingCategories = await _context.Categories.ToListAsync();
            List<Category> ProductCategories = new List<Category>();

            foreach (CategoryVM categoryVM in categories)
            {
                Category ProductCat = ExistingCategories.FirstOrDefault(c => c.Name == categoryVM.Name);

                if (ProductCat != null)
                {
                    ProductCategories.Add(ProductCat);
                } else
                {
                    Category newCat = new Category()
                    {
                        Name = categoryVM.Name,
                    };
                    _context.Categories.Add(newCat);
                    ProductCategories.Add(newCat);
                }
            }

            return ProductCategories;
        }
    }
}
