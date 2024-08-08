using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImagesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadProductImages(ProductImagesVM data)
        {
            List<ProductImage> savedImages = await SaveImages(data.Images, data.ProductId);

            List<ProductImageVM> savedData = new List<ProductImageVM>();
            foreach (ProductImage image in savedImages)
            {
                ProductImageVM productImageVM = new ProductImageVM()
                {
                    Id = image.Id,
                    FileName = image.FileName,
                    FilePath = image.FilePath,
                };

                savedData.Add(productImageVM);
            }

            return Json(new { status = "Success", images = JsonConvert.SerializeObject(savedData) });
        }

        public async Task<List<ProductImage>> SaveImages(List<IFormFile> files, Guid productId)
        {
            List<ProductImage> uploadedList = new List<ProductImage>();
            string imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");

            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            foreach (IFormFile file in files)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(imagesFolder, fileName);

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                ProductImage productImage = new ProductImage()
                {
                    ProductId = productId,
                    FileName = file.FileName,
                    FilePath = @"\ProductImages\" + fileName,
                    SortOrder = 99,
                };

                uploadedList.Add(productImage);
                await _context.ProductImages.AddAsync(productImage);
            }

            await _context.SaveChangesAsync();

            return uploadedList;
        }

        public async Task<IActionResult> GetProductImages(Guid productId)
        {
            List<ProductImage> productImages = await _context.ProductImages.Where(pi => pi.ProductId == productId).ToListAsync();
            List<ProductImageVM> productImageVM = new List<ProductImageVM>();

            if (productImages.Count > 0)
            {
                foreach (ProductImage productImage in productImages)
                {
                    ProductImageVM imageVM = new ProductImageVM()
                    {
                        Id = productImage.Id,
                        FileName = productImage.FileName,
                        FilePath = productImage.FilePath,
                    };

                    productImageVM.Add(imageVM);
                }
            }

            return Json(new { status = "Success", images = JsonConvert.SerializeObject(productImageVM) });

        }

        public async Task<IActionResult> DeleteProductImages(Guid productId, List<int> imageId)
        {
            List<ProductImage> productImages = await _context.ProductImages.Where(pi => pi.ProductId == productId && pi.IsFeatured != true).ToListAsync();

            List<int> successDelete = new List<int>();
            if (imageId != null && productImages != null)
            {
                foreach (int id in imageId)
                {
                    ProductImage toBeDeleted = productImages.Where(pi => pi.Id == id).FirstOrDefault();

                    if (toBeDeleted != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, toBeDeleted.FilePath.TrimStart('\\'));

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        _context.ProductImages.Remove(toBeDeleted);
                        successDelete.Add(id);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return Json(new { status = "Success", deleted = JsonConvert.SerializeObject(successDelete) });
        }
    }
}
