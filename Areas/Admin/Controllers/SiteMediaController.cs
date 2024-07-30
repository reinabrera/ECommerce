using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SiteMediaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SiteMediaController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(List<IFormFile> file)
        {
            List<SiteMedia> savedImages = await SaveImages(file);

            return Json(new { status = "Success", images = JsonConvert.SerializeObject(savedImages) });
        }


        [HttpPost]
        public async Task<IActionResult> GetImages()
        {
            List<SiteMedia> images = await _context.SiteMedias.OrderByDescending(sm => sm.Id).ToListAsync();

            return Json(new { status = "Success", images = JsonConvert.SerializeObject(images) });
        }

        public async Task<List<SiteMedia>> SaveImages(List<IFormFile> files)
        {
            List<SiteMedia> uploadedList = new List<SiteMedia>();
            string imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Media");

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

                SiteMedia Image = new SiteMedia()
                {

                    FileName = file.FileName,
                    FilePath = @"\Media\" + fileName,
                };

                uploadedList.Add(Image);
                await _context.SiteMedias.AddAsync(Image);
            }

            await _context.SaveChangesAsync();

            return uploadedList;
        }

        public async Task<IActionResult> DeleteImages(List<int> fileId)
        {
            List<int> successDelete = new List<int>();

            foreach (int id in fileId)
            {
                SiteMedia file = await _context.SiteMedias.FindAsync(id);

                if (file != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, file.FilePath.TrimStart('\\'));

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    _context.SiteMedias.Remove(file);
                    successDelete.Add(id);
                }
            }

            await _context.SaveChangesAsync();

            return Json(new { status = "Success", deleted = JsonConvert.SerializeObject(successDelete) });
        }
    }
}
