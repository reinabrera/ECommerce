using ECommerce2.Models;
using ECommerce2.Utility;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
        public DbSet<AdditionalImage> ProductAdditionalImages { get; set; }
        public DbSet<AdditionalDetail> ProductAdditionalDetails { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<SiteMedia> SiteMedias { get; set; }
        public DbSet<SpecialPromotion> SpecialPromotions { get; set; }
        public DbSet<Variant> Variations { get; set; }
        public DbSet<AttributeModel> Attributes { get; set; }
        public DbSet<Term> AttributeTerms { get; set; }
        public DbSet<ProductAttributeJoin> ProductAttributeJoinTable { get; set; }
        public DbSet<ProductTermJoin> ProductTermJoinTable { get; set; }
        public DbSet<TeamMember> Team { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
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

            builder.Entity<ProductCategories>()
                .HasIndex(pc => new { pc.ProductId, pc.Order })
                .IsUnique();

            builder.Entity<AdditionalImage>()
                .HasOne(p => p.Image)
                .WithMany()
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Partnership>()
                .HasOne(p => p.Image)
                .WithMany()
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<SpecialPromotion>()
                .HasOne(sp => sp.SiteMedia)
                .WithMany()
                .HasForeignKey(sp => sp.SiteMediaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Term>()
                .HasOne(at => at.Attribute)
                .WithMany(at => at.Terms)
                .HasForeignKey(at => at.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasMany(p => p.Attributes)
                .WithMany(p => p.Products)
                .UsingEntity<ProductAttributeJoin>();

            builder.Entity<Product>()
                .HasMany(p => p.SelectedTerms)
                .WithMany()
                .UsingEntity<ProductTermJoin>();

            builder.Entity<Variant>()
                .HasMany(p => p.Terms)
                .WithMany()
                .UsingEntity<TermVariation>();

            builder.Entity<Variant>()
                .HasOne(v => v.Image)
                .WithMany()
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Variant>()
                .HasIndex(v => new { v.ProductId, v.TermsConcatenated })
                .IsUnique();

            builder.Entity<TeamMember>()
                .HasOne(tm => tm.Image)
                .WithMany()
                .HasForeignKey(tm => tm.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.User)
                .WithMany(ci => ci.CartItems)
                .HasForeignKey(ci => ci.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            /** NOTE: Create a function for client casade delete **/
            builder.Entity<CartItem>()
                .HasOne(ci => ci.Variant)
                .WithMany(ci => ci.CartItems)
                .HasForeignKey(ci => ci.VariantId)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.Entity<Review>()
                .HasOne<Product>()
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Seed();
        }
    }
}
