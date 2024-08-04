using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce2.Data;
using ECommerce2.Models;
using Newtonsoft.Json;
using System.Xml.Linq;
using ECommerce2.Models.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Framework;

namespace ECommerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductAttributesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductAttributesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductAttributes
        public async Task<IActionResult> Index()
        {
            List<AttributeModel> attributes = await _context.Attributes.Select(a => new AttributeModel
            {
                Id = a.Id,
                Name = a.Name,
                Type = a.Type,
                Terms = a.Terms.Take(3).ToList()
            }).ToListAsync();

            return View(attributes);
        }

        // GET: ProductAttributes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            return View(productAttribute);
        }

        // GET: ProductAttributes/Create
        public IActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (AttributeType item in Enum.GetValues(typeof(AttributeType)))
            {
                items.Add(new SelectListItem() { Text = item.ToString(), Value = item.ToString() });
            }

            ViewBag.AttributeTypes = items;

            return View();
        }

        // POST: ProductAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] AttributeModel productAttribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productAttribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productAttribute);
        }

        // GET: ProductAttributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute = await _context.Attributes.Include(a => a.Terms).FirstOrDefaultAsync(a => a.Id == id);
            if (productAttribute == null)
            {
                return NotFound();
            }
            return View(productAttribute);
        }

        // POST: ProductAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Terms")] AttributeModel productAttribute)
        {
            if (id != productAttribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAttribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAttributeExists(productAttribute.Id))
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
            return View(productAttribute);
        }

        // GET: ProductAttributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            return View(productAttribute);
        }

        // POST: ProductAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productAttribute = await _context.Attributes.FindAsync(id);
            if (productAttribute != null)
            {
                _context.Attributes.Remove(productAttribute);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductAttributeExists(int id)
        {
            return _context.Attributes.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> GetAttributes()
        {
            var attributes = await _context.Attributes.Select(a => new { a.Id, a.Name }).ToListAsync();

            return Json(new { status = "Success", attributes = JsonConvert.SerializeObject(attributes) });
        }

        [HttpPost]
        public async Task<IActionResult> GetAttributeTerms(int id)
        {
            var terms = await _context.AttributeTerms.Where(at => at.AttributeId == id).Select(a => new { a.Id, a.Name }).ToListAsync();

            return Json(new { status = "Success", terms = JsonConvert.SerializeObject(terms) });
        }

        [HttpPost]
        public async Task<IActionResult> SaveProductAttributes([FromBody] ProductAttributeVM data)
        {
            Product product = await _context.Products.Include(p => p.Attributes).Include(p => p.SelectedTerms).FirstOrDefaultAsync(p => p.Id == data.ProductId);

            if (product == null) return Json(new { status = "Failed", message = "Product does not exist" });



            /** Removing Attributes */
            List<int> attrIds = data.Attributes.Select(a => a.Id).ToList();
            foreach (AttributeModel attribute in product.Attributes)
            {
                if (!attrIds.Contains(attribute.Id))
                {
                    product.Attributes.Remove(attribute);
                }

                foreach (Term term in product.SelectedTerms)
                {
                    if (term.AttributeId == attribute.Id)
                    {
                        product.SelectedTerms.Remove(term);
                    }
                }
            }

            if (data.Attributes.Count > 0)
            {
                foreach (AttributeVM attribute in data.Attributes)
                {
                    AttributeModel productAttribute = await _context.Attributes.FirstOrDefaultAsync(a => a.Id == attribute.Id);

                    if (productAttribute != null)
                    {
                        product.Attributes.Add(productAttribute);
                    }


                    /** Removing Terms */
                    List<int> termIds = attribute.Terms.Select(a => a.Id).ToList();
                    foreach (Term term in product.SelectedTerms)
                    {
                        if (term.AttributeId == attribute.Id && termIds.Contains(term.Id))
                        {
                            product.SelectedTerms.Remove(term);
                        }
                    }

                    foreach (TermVM term in attribute.Terms)
                    {
                        Term attributeTerm = await _context.AttributeTerms.FirstOrDefaultAsync(at => at.Id == term.Id);
                        if (attributeTerm != null)
                        {
                            product.SelectedTerms.Add(attributeTerm);
                        }
                    }
                }
            }


            _context.Products.Update(product);
            _context.SaveChanges();

            return Json(new { status = "Success" });
        }

        [HttpPost]
        public async Task<IActionResult> GetProductAttributes(Guid productId)
        {
            if (productId == Guid.Empty) return Json(new { status = "Failed", message = "Product id is null." });

            Product product = await _context.Products.Include(p => p.Attributes).Include(p => p.SelectedTerms).FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) return Json(new { status = "Failed", message = "Product does not exist." });

            var result = new
            {
                Attributes = product.Attributes.Select(a => new
                {
                    a.Id,
                    a.Name,
                    Terms = product.SelectedTerms.Where(st => st.AttributeId == a.Id).OrderBy(st => st.Id).Select(st => new
                    {
                        st.Id,
                        st.Name,
                    }).ToList()
                }).ToList()
            };

            return Json(new { status = "Success", attributeTerms = JsonConvert.SerializeObject(result) });
        }

        [HttpPost]
        public async Task<IActionResult> GenerateProductVariation(Guid productId)
        {
            if (productId == Guid.Empty) return Json(new { status = "Failed", message = "Product id is null" });

            Product product = await _context.Products
                .Include(p => p.SelectedTerms)
                .Include(p => p.Variations)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) return Json(new { status = "Failed", message = "Product does not exist." });

            List<Term> productTerms = product.SelectedTerms.ToList();

            List<List<Term>> termsDividedByAttr = productTerms.GroupBy(a => a.AttributeId).Select(g => g.ToList()).ToList();
            List<Variant> generatedVariations = GenerateTermCombinations(termsDividedByAttr);

            List<Variant> added = generatedVariations
                .Where(gv => !product.Variations
                .Any(v => v.TermsConcatenated == gv.TermsConcatenated))
                .Select(gv => { gv.ListPrice = product.ListPrice; gv.SalePrice = product.SalePrice; return gv; })
                .ToList();

            product.Variations = generatedVariations;

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return Json(new { status = "Success", variations = JsonConvert.SerializeObject(added) });
        }

        public List<Variant> GenerateTermCombinations(List<List<Term>> terms, int n = 0, List<Term> current = null, List<Variant> variations = null)
        {
            if (current == null) current = new List<Term>();
            if (variations == null) variations = new List<Variant>();

            if (n == terms.Count)
            {
                Variant variant = new Variant()
                {
                    Terms = new List<Term>(current),
                    TermsConcatenated = string.Join(", ", current.OrderBy(c => c.Id).Select(c => c.Id)),
                };
                variations.Add(variant);
            }
            else
            {
                foreach (Term term in terms[n])
                {
                    current.Add(term);
                    GenerateTermCombinations(terms, n + 1, current, variations);
                    current.RemoveAt(current.Count - 1);
                }
            }

            return variations;
        }

        [HttpPost]
        public async Task<IActionResult> GetProductVariations(Guid productId)
        {

            if (productId == Guid.Empty) return Json(new { status = "Failed", message = "Product id is null" });

            bool productExist = await _context.Products.AnyAsync(p => p.Id == productId);

            if (!productExist) return Json(new { status = "Failed", message = "Product does not exist" });

            List<Variant> variations = await _context.Variations.Include(v => v.Terms).Include(v => v.Image).Where(v => v.ProductId == productId).ToListAsync();

            return Json(new { status = "Success", variations = JsonConvert.SerializeObject(variations) });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductVariations([FromBody] ProductVariationVM data)
        {
            if (data == null) return Json(new { status = "Failed", message = "There was an error processing your request." });

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == data.ProductId);
            if (product == null) return Json(new { status = "Failed", message = "Product does not exist" });

            List<Variant> updated = new List<Variant>();

            decimal? salePriceMin = int.MaxValue;
            decimal? salePriceMax = 0;

            decimal? listPriceWithoutSalePriceMin = int.MaxValue;
            decimal? listPriceWithoutSalePriceMax = 0;

            foreach (VariantVM variantVM in data.Variants)
            {
                Variant variant = await _context.Variations
                    .Include(v => v.Terms)
                    .Include(v => v.Image)
                    .FirstOrDefaultAsync(v => v.Id == variantVM.Id);

                if (variant != null)
                {
                    variant.ListPrice = variantVM.ListPrice;
                    variant.SalePrice = variantVM.SalePrice;
                    variant.Inventory = variantVM.Inventory;
                    if (variantVM.ImageId != null)
                    {
                        ProductImage image = await _context.ProductImages.FindAsync(variantVM.ImageId);

                        if (image != null)
                        {
                            variant.Image = image;
                        }
                    }
                    else
                    {
                        variant.ImageId = null;
                        variant.Image = null;
                    }

                    _context.Variations.Update(variant);
                    updated.Add(variant);
                }

                if (variant.SalePrice != null)
                {
                    if (variant.SalePrice < salePriceMin) salePriceMin = variant.SalePrice;
                    if (variant.SalePrice > salePriceMax) salePriceMax = variant.SalePrice;
                } else
                {
                    if (variant.ListPrice < listPriceWithoutSalePriceMin) listPriceWithoutSalePriceMin = variant.ListPrice;
                    if (variant.ListPrice > listPriceWithoutSalePriceMax) listPriceWithoutSalePriceMax = variant.ListPrice;
                }
            }

            if (salePriceMin < listPriceWithoutSalePriceMin)
            {
                product.MinPrice = salePriceMin;
            }
            else
            {
                product.MinPrice = listPriceWithoutSalePriceMin;
            }

            if (salePriceMax > listPriceWithoutSalePriceMax)
            {
                product.MaxPrice = salePriceMax;
            }
            else
            {
                product.MaxPrice = listPriceWithoutSalePriceMax;
            }

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            var SerializedUpdated = JsonConvert.SerializeObject(updated);

            return Json(new { status = "Success", update = SerializedUpdated });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductVariation(Guid productId, int variantId)
        {
            bool productExist = await _context.Products.AnyAsync(p => p.Id == productId);
            if (!productExist) return Json(new { status = "Failed", message = "Product does not exist" });

            Variant productVariant = await _context.Variations.FirstOrDefaultAsync(v => v.ProductId == productId && v.Id == variantId);

            if (productVariant == null) return Json(new { status = "Failed", message = "Product variant does not exist." });

            _context.Variations.Remove(productVariant);

            await _context.SaveChangesAsync();

            return Json(new { status = "Success", deleted = variantId });
        }
    }
}