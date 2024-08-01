using ECommerce2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace ECommerce2.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductsController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GetProductImageByVariant(Guid productId, List<int> termId)
        {
            termId = termId.OrderBy(x => x).ToList();

            string concatenatedTermIds = string.Join(", ", termId);

            string imgUrl = await _context.Variations
                .Include(v => v.Image)
                .Where(v => v.ProductId == productId && v.TermsConcatenated == concatenatedTermIds)
                .Select(v => v.Image.FilePath).FirstOrDefaultAsync();

            return Json(new { status = "Success", data = JsonConvert.SerializeObject(imgUrl) });
        }

    }
}
