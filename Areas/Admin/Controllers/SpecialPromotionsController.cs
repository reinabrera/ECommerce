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
    public class SpecialPromotionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialPromotionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpecialPromotions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.SpecialPromotions.ToListAsync();
            return View(applicationDbContext);
        }

        // GET: SpecialPromotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPromotion = await _context.SpecialPromotions
                .Include(s => s.SiteMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialPromotion == null)
            {
                return NotFound();
            }

            SpecialPromotionVM specialPromotionVM = new SpecialPromotionVM()
            {
                Id = specialPromotion.Id,
                Title = specialPromotion.Title,
                Description = specialPromotion.Description,
                Url = specialPromotion.Url,
                ButtonText = specialPromotion.ButtonText,
                SiteMedia = specialPromotion.SiteMedia,
            };

            return View(specialPromotionVM);
        }

        // GET: SpecialPromotions/Create
        public IActionResult Create()
        {
            SpecialPromotionVM specialPromotionVM = new();
            return View(specialPromotionVM);
        }

        // POST: SpecialPromotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Url, ButtonText, SiteMediaId")] SpecialPromotionVM specialPromotion)
        {
            if (ModelState.IsValid)
            {
                SpecialPromotion create = new SpecialPromotion()
                {
                    Id = specialPromotion.Id,
                    Title = specialPromotion.Title,
                    Description = specialPromotion.Description,
                    Url = specialPromotion.Url,
                    ButtonText = specialPromotion.ButtonText,
                    SiteMediaId = specialPromotion.SiteMediaId,
                };
                _context.Add(create);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialPromotion);
        }

        // GET: SpecialPromotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPromotion = await _context.SpecialPromotions.Include(p => p.SiteMedia).FirstOrDefaultAsync(p => p.Id == id);

            if (specialPromotion == null)
            {
                return NotFound();
            }

            SpecialPromotionVM specialPromotionVM = new SpecialPromotionVM()
            {
                Id = specialPromotion.Id,
                Title = specialPromotion.Title,
                Description = specialPromotion.Description,
                Url = specialPromotion.Url,
                ButtonText = specialPromotion.ButtonText,
                SiteMediaId = specialPromotion.SiteMediaId,
                SiteMedia = specialPromotion.SiteMedia != null ? specialPromotion.SiteMedia : null,
            };

            return View(specialPromotionVM);
        }

        // POST: SpecialPromotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Url,ButtonText, SiteMediaId")] SpecialPromotionVM specialPromotion)
        {
            if (id != specialPromotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SpecialPromotion edit = new SpecialPromotion()
                    {
                        Id = specialPromotion.Id,
                        Title = specialPromotion.Title,
                        Description = specialPromotion.Description,
                        Url = specialPromotion.Url,
                        ButtonText = specialPromotion.ButtonText,
                        SiteMediaId = specialPromotion.SiteMediaId,
                    };
                    _context.Update(edit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialPromotionExists(specialPromotion.Id))
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
            return View(specialPromotion);
        }

        // GET: SpecialPromotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPromotion = await _context.SpecialPromotions
                .Include(s => s.SiteMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialPromotion == null)
            {
                return NotFound();
            }

            SpecialPromotion specialPromotionVM = new SpecialPromotion()
            {
                Id = specialPromotion.Id,
                Title = specialPromotion.Title,
                Description = specialPromotion.Description,
                Url = specialPromotion.Url,
                ButtonText = specialPromotion.ButtonText,
                SiteMedia = specialPromotion.SiteMedia,
            };

            return View(specialPromotionVM);
        }

        // POST: SpecialPromotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialPromotion = await _context.SpecialPromotions.FindAsync(id);
            if (specialPromotion != null)
            {
                _context.SpecialPromotions.Remove(specialPromotion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialPromotionExists(int id)
        {
            return _context.SpecialPromotions.Any(e => e.Id == id);
        }
    }
}
