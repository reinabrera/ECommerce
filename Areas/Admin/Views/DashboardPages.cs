using Microsoft.AspNetCore.Mvc.Rendering;

#nullable disable

namespace ECommerce2.Areas.Admin.Views
{
    public class DashboardPages
    {
        public static string Products => "Products";
        public static string Attributes => "Attributes";
        public static string SpecialPromotions => "SpecialPromotions";
        public static string TeamMembers => "TeamMembers";
        public static string Partnerships => "Partnerships";

        public static string ProductsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Products);
        public static string AttributesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Attributes);
        public static string SpecialPromotionsNavClass(ViewContext viewContext) => PageNavClass(viewContext, SpecialPromotions);
        public static string TeamMembersNavClass(ViewContext viewContext) => PageNavClass(viewContext, TeamMembers);
        public static string PartnershipsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Partnerships);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string ?? "";
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
