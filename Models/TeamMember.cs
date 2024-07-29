namespace ECommerce2.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? ImageId { get; set; }
        public SiteMedia? Image { get; set; }
    }
}
