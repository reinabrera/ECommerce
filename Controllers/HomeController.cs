using ECommerce2.Data;
using ECommerce2.Models;
using ECommerce2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ECommerce2.Controllers
{
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
                .Include(p => p.Logo)
                .ToListAsync();

            List<SpecialPromotion> SpecialPromotions = await _context.SpecialPromotions.Include(sp => sp.SiteMedia).ToListAsync();

            homePageVM.Partnerships = Partnerships;
            homePageVM.SpecialPromotions = SpecialPromotions;

            return View(homePageVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
