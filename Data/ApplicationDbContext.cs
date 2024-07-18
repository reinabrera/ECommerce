using ECommerce2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductAdditionalImage> ProductAdditionalImages { get; set; }
        public DbSet<ProductAdditionalDetail> ProductAdditionalDetails { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<PartnershipLogo> PartnershipLogos { get; set; }
        public DbSet<SiteMedia> SiteMedias { get; set; }
        public DbSet<SpecialPromotion> SpecialPromotions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasMany(p => p.AdditionalImages)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Products)
                .UsingEntity<ProductCategories>();

            builder.Entity<ProductAdditionalImage>()
                .HasOne(p => p.Image)
                .WithMany()
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Partnership>()
                .HasOne(p => p.Logo)
                .WithOne(p => p.Partnership)
                .HasForeignKey<PartnershipLogo>(p => p.PartnershipId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<SpecialPromotion>()
                .HasOne(sp => sp.SiteMedia)
                .WithMany()
                .HasForeignKey(sp => sp.SiteMediaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
