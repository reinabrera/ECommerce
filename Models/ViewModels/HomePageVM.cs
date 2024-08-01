namespace ECommerce2.Models.ViewModels
{
    public class HomePageVM
    {
        public List<Partnership> Partnerships { get; set; }
        public List<SpecialPromotion> SpecialPromotions { get; set; }
        public List<ProductCardVM> FeaturedProducts { get; set; }
    }
}
