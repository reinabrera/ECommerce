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
using Microsoft.AspNetCore.Authorization;

namespace ECommerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
                    ImageId = partnership.ImageId,
                };


                _context.Add(CreatePartnership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnership);
        }


        // GET: Partnerships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnership = await _context.Partnerships.Include(p => p.Image).FirstOrDefaultAsync(p => p.Id == id);

            if (partnership == null)
            {
                return NotFound();
            }

            PartnershipVM partnershipVM = new PartnershipVM()
            {
                CompanyName = partnership.CompanyName,
                CompanyWebsite = partnership.CompanyWebsite,
                Image = partnership.Image,
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
                    Partnership partnership = await _context.Partnerships.Include(p => p.Image).FirstOrDefaultAsync();

                    if (partnership == null) return NotFound();

                    partnership.CompanyName = partnershipVM.CompanyName;
                    partnership.CompanyWebsite = partnershipVM.CompanyWebsite;
                    partnership.ImageId = partnershipVM.ImageId;

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
            var partnership = await _context.Partnerships.FirstOrDefaultAsync();

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnershipExists(int id)
        {
            return _context.Partnerships.Any(e => e.Id == id);
        }
    }
}
