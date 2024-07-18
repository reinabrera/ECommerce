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

namespace ECommerce2.Controllers
{
    public class PartnershipsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public PartnershipsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Partnerships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partnerships.ToListAsync());
        }

        // GET: Partnerships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnership = await _context.Partnerships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnership == null)
            {
                return NotFound();
            }

            return View(partnership);
        }

        // GET: Partnerships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partnerships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartnershipVM partnership)
        {
            if (ModelState.IsValid)
            {

                Partnership CreatePartnership = new Partnership()
                {
                    CompanyName = partnership.CompanyName,
                    CompanyWebsite = partnership.CompanyWebsite,
                };

                CreatePartnership.Logo = UploadLogo(partnership.FileUpload);

                if (CreatePartnership.Logo == null)
                {
                    partnership.FileUpload = null;
                    return View(partnership);
                }

                _context.Add(CreatePartnership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnership);
        }

        public PartnershipLogo? UploadLogo(IFormFile file)
        {
            string logoFolder = Path.Combine(_webHostEnvironment.WebRootPath, "PartnershipLogos");

            if (!Directory.Exists(logoFolder))
            {
                Directory.CreateDirectory(logoFolder);
            }

            string FileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string FileSavePath = Path.Combine(logoFolder, FileName);

            using (FileStream stream = new FileStream(FileSavePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (System.IO.File.Exists(FileSavePath))
            {
                PartnershipLogo Logo = new PartnershipLogo()
                {
                    FileName = FileName,
                    FilePath = @"\PartnershipLogos\" + FileName
                };

                return Logo;
            }
            return null;
        }

        // GET: Partnerships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnership = await _context.Partnerships.Include(x => x.Logo).FirstOrDefaultAsync(p => p.Id == id);

            if (partnership == null)
            {
                return NotFound();
            }

            PartnershipVM partnershipVM = new PartnershipVM()
            {
                CompanyName = partnership.CompanyName,
                CompanyWebsite = partnership.CompanyWebsite,
                Logo = partnership.Logo,
            };

            return View(partnershipVM);
        }

        // POST: Partnerships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PartnershipVM partnershipVM)
        {
            if (id != partnershipVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Partnership partnership = await _context.Partnerships.Include(p => p.Logo).FirstOrDefaultAsync();

                    if (partnership == null) return NotFound();

                    partnership.CompanyName = partnershipVM.CompanyName;
                    partnership.CompanyWebsite = partnershipVM.CompanyWebsite;

                    /** Updating Company Logo */
                    if (partnershipVM.FileUpload != null)
                    {
                        PartnershipLogo logo = UploadLogo(partnershipVM.FileUpload);

                        if (logo == null) return View(partnershipVM);

                        /** Removing Old Company Logo */
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, partnership.Logo.FilePath.TrimStart('\\'));

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                        partnership.Logo = logo;
                    }

                    _context.Update(partnership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnershipExists(partnershipVM.Id))
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
            return View(partnershipVM);
        }

        // GET: Partnerships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnership = await _context.Partnerships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnership == null)
            {
                return NotFound();
            }

            return View(partnership);
        }

        // POST: Partnerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partnership = await _context.Partnerships.Include(p => p.Logo).FirstOrDefaultAsync();
            //PartnershipLogo logo = await _context.PartnershipLogos.Include(p => p.Logo).FirstOrDefaultAsync(p => p.PartnershipId == partnership.Id);

            if (partnership != null)
            {
                if (partnership.Logo != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, partnership.Logo.FilePath.TrimStart('\\'));

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Partnerships.Remove(partnership);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnershipExists(int id)
        {
            return _context.Partnerships.Any(e => e.Id == id);
        }
    }
}
