using Microsoft.AspNetCore.Identity;

namespace ECommerce2.Models.ViewModels
{
    public class ProductImagesVM
    {
        public Guid ProductId { get; set; }
        public List<IFormFile> Images { get; set; }
    }

    public class ProductImageVM
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
